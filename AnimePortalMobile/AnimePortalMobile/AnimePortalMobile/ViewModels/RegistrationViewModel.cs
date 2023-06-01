using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimePortalMobile.Abstractions;
using AnimePortalMobile.Constants;
using AnimePortalMobile.Models.DTOs.Jwt;
using BLL.ApiClient;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AnimePortalMobile.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private string _error;
        public string Error
        {
            get => _error;
            set => SetField(ref _error, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetField(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetField(ref _password, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public ICommand Register { get; }

        public RegistrationViewModel(AnimePortalApiClient animePortalApiClient, ISaveHandler<string, string> saveHandler) : base(animePortalApiClient, saveHandler)
        {
            Register = new AsyncCommand(RegisterMethodAsync);
        }

        private async Task RegisterMethodAsync()
        {
            JwtOnlyTokenDto token = await _apiClient.PostAsync<RegisterUser, JwtOnlyTokenDto>(
                "/api/jwt-auth/register",
                new RegisterUser(){Name = Login, Password = Password, Email = Email},
                cookies =>
                {
                    _saveHandler.SaveDataAsync(PreferencesNames.RefreshToken,
                        cookies.FirstOrDefault(cookie => cookie.Name == PreferencesNames.RefreshToken)?.Value);
                });

            await _saveHandler.SaveDataAsync(PreferencesNames.AccessToken, token?.Token);

            if (token != null)
            {
                await RedirectToMethodAsync("2");
            }
            else
            {
                Error = "Error";
            }
        }
    }
}