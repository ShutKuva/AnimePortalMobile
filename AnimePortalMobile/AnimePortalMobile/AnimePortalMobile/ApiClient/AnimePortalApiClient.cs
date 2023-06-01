using AnimePortalMobile.Models.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL.ApiClient
{
    public class AnimePortalApiClient
    {
        private readonly ApiConfigurations _apiConfigurations;

        public AnimePortalApiClient(IOptions<ApiConfigurations> apiConfigurations)
        {
            _apiConfigurations = apiConfigurations.Value ?? throw new ArgumentNullException();
        }

        public async Task<TResponse> GetAsync<TRequest, TResponse>(string uri, TRequest request, Action<IEnumerable<Cookie>> cookieResolver) where TResponse : class
        {
            Uri requestUri = new Uri(new Uri(_apiConfigurations.BaseUrl), AddAsQuery(uri, request));
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            CookieContainer cookies = new CookieContainer();
            clientHandler.CookieContainer = cookies;
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Cookie> mappedCookies = cookies.GetCookies(requestUri).Cast<Cookie>();
                cookieResolver?.Invoke(mappedCookies);

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request, Action<IEnumerable<Cookie>> cookieResolver) where TResponse : class
        {
            Uri requestUri = new Uri(new Uri(_apiConfigurations.BaseUrl), uri);
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            string serializedRequest = JsonConvert.SerializeObject(request);
            StringContent body = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            CookieContainer cookies = new CookieContainer();
            clientHandler.CookieContainer = cookies;
            HttpResponseMessage response = await client.PostAsync(requestUri, body);

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Cookie> mappedCookies = cookies.GetCookies(requestUri).Cast<Cookie>();
                cookieResolver?.Invoke(mappedCookies);

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        private string AddAsQuery<T>(string uri, T objForQuery)
        {
            if (objForQuery == null)
            {
                return uri;
            }

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