using System.Threading.Tasks;
using Xamarin.Essentials;
using AnimePortalMobile.Abstractions;

namespace AnimePortalMobile.SavingData
{
    public class PreferencesSaveHandler : ISaveHandler<string, string>
    {
        public Task SaveDataAsync(string key, string value)
        {
            if (value == null) 
            {
                return Task.CompletedTask;
            }

            Preferences.Set(key, value);

            return Task.CompletedTask;
        }

        public Task<string> GetDataAsync(string key, string defaultValue)
        {
            return Task.FromResult(Preferences.Get(key, defaultValue));
        }

        public Task RemoveDataAsync(string key)
        {
            Preferences.Remove(key);

            return Task.CompletedTask;
        }

        public Task<bool> IsDataExistAsync(string key)
        {
            return Task.FromResult(Preferences.ContainsKey(key));
        }
    }
}