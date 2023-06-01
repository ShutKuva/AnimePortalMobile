using AnimePortalMobile.Abstractions;
using AnimePortalMobile.ViewModels;
using AnimePortalMobile.Views;
using BLL.ApiClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimePortalMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private readonly ISaveHandler<string, string> _saveHandler;
        private readonly AnimePortalApiClient _apiClient;

        public MainPage(AnimePortalApiClient apiClient, ISaveHandler<string, string> saveHandler)
        {
            InitializeComponent();

            _apiClient = apiClient;
            _saveHandler = saveHandler;
        }

        protected override void OnAppearing()
        {
            NavigationPage nextPage = new NavigationPage(new LoginView(new LoginViewModel(_apiClient, _saveHandler)));
            NavigationPage.SetHasNavigationBar(nextPage, false);

            Navigation.PushAsync(nextPage);
        }
    }
}