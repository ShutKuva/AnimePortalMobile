using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimePortalMobile.Abstractions;
using AnimePortalMobile.Constants;
using AnimePortalMobile.Models.DTOs.Jwt;
using BLL.ApiClient;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace AnimePortalMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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

        public ICommand LogIn { get; }

        public LoginViewModel(AnimePortalApiClient apiClient, ISaveHandler<string, string> saveHandler) : base(apiClient, saveHandler)
        {
            LogIn = new AsyncCommand(LogInMethodAsync);
        }

        private async Task LogInMethodAsync()
        {
            JwtOnlyTokenDto token = await _apiClient.PostAsync<LoginUser, JwtOnlyTokenDto>(
                "/api/jwt-auth/login",
                new LoginUser() { NameOrEmail = Login, Password = Password },
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
        }
    }
}