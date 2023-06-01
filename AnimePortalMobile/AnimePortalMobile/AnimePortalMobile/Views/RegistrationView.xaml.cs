using AnimePortalMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace AnimePortalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationView
    {
        public RegistrationViewModel ViewModel { get; set; }

        public RegistrationView(RegistrationViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;

            BindingContext = viewModel;
        }
    }
}