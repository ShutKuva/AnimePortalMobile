using AnimePortalMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimePortalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView
    {
        public LoginViewModel ViewModel { get; set; }

        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;

            BindingContext = viewModel;
        }
    }
}