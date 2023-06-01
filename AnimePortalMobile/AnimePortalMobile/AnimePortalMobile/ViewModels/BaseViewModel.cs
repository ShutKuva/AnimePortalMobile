using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimePortalMobile.Abstractions;
using AnimePortalMobile.Enums;
using AnimePortalMobile.Views;
using BLL.ApiClient;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AnimePortalMobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly INavigation _navigation;

        protected readonly AnimePortalApiClient _apiClient;
        protected readonly ISaveHandler<string, string> _saveHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RedirectTo { get; }

        public BaseViewModel(AnimePortalApiClient apiClient, ISaveHandler<string, string> saveHandler)
        {
            RedirectTo = new AsyncCommand<string>(RedirectToMethodAsync);
            _navigation = Application.Current.MainPage.Navigation;

            _apiClient = apiClient;
            _saveHandler = saveHandler;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected async Task RedirectToMethodAsync(string page)
        {
            //await _navigation.PopAsync();
            NavigationPage nextPage = new NavigationPage();
            switch (Enum.Parse(typeof(Pages), page))
            {
                case Pages.Login:
                    nextPage = new NavigationPage(new LoginView(new LoginViewModel(_apiClient, _saveHandler)));
                    break;
                case Pages.Registration:
                    nextPage = new NavigationPage(new RegistrationView(new RegistrationViewModel(_apiClient, _saveHandler)));
                    break;
                case Pages.Catalog:
                    nextPage = new NavigationPage(new CatalogView(new CatalogViewModel(_apiClient, _saveHandler)));
                    break;
            }

            NavigationPage.SetHasNavigationBar(nextPage, false);

            await _navigation.PushAsync(nextPage);
        }
    }
}