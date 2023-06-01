using AnimePortalMobile.Abstractions;
using AnimePortalMobile.Models.Configurations;
using AnimePortalMobile.SavingData;
using BLL.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace AnimePortalMobile
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            ServiceCollection sc = new ServiceCollection();

            RegisterDependencies(sc);

            ServiceProvider sp = sc.BuildServiceProvider();

            NavigationPage mainPage = new NavigationPage(sp.GetRequiredService<MainPage>());

            NavigationPage.SetHasNavigationBar(mainPage, false);

            MainPage = mainPage;
        }

        private void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MainPage>();
            serviceCollection.AddScoped<AnimePortalApiClient>();
            serviceCollection.AddScoped<ISaveHandler<string, string>, PreferencesSaveHandler>();
            serviceCollection.Configure<ApiConfigurations>(config =>
            {
                config.BaseUrl = "https://animeportalwindowdev.azurewebsites.net";
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
