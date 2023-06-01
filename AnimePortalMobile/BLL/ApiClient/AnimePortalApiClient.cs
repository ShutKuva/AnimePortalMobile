using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using Core.Configurations;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace BLL.ApiClient
{
    public class AnimePortalApiClient
    {
        private readonly HttpClient _httpClient;

        public AnimePortalApiClient(ApiConfigurations apiConfigurations)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiConfigurations.BaseUrl);
        }

        public async Task<TResponse?> GetAsync<TRequest, TResponse>(string uri, TRequest request, Action<IEnumerable<Cookie>> cookieResolver) where TResponse : class
        {
            Uri requestUri = new Uri(AddAsQuery(uri, request), UriKind.Relative);
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                CookieContainer cookies = new CookieContainer();
                IEnumerable<Cookie> mappedCookies = cookies.GetCookies(requestUri);
                cookieResolver(mappedCookies);

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest request, Action<IEnumerable<Cookie>> cookieResolver) where TResponse : class
        {
            Uri requestUri = new Uri(uri, UriKind.Relative);
            string serializedRequest = JsonConvert.SerializeObject(request);
            StringContent body = new StringContent(serializedRequest, Encoding.UTF8, MediaTypeNames.Application.Json);
            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, body);

            if (response.IsSuccessStatusCode)
            {
                CookieContainer cookies = new CookieContainer();
                IEnumerable<Cookie> mappedCookies = cookies.GetCookies(requestUri);
                cookieResolver(mappedCookies);

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        private string AddAsQuery<T>(string uri, T objForQuery)
        {
            StringBuilder sb = new StringBuilder(uri);

            sb.Append("?");

            bool isFirst = true;

            foreach (PropertyInfo property in objForQuery.GetType().GetProperties())
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sb.Append("&");
                }

                sb.Append($"{JsonNamingPolicy.CamelCase.ConvertName(property.Name)}={property.GetValue(objForQuery)}");
            }

            return sb.ToString();
        }
    }
}