using AnimePortalMobile.ViewModels;
using Xamarin.Forms;

namespace AnimePortalMobile
{
    public class ViewModelDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoginView { get; set; }
        public DataTemplate RegistrationView { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is LoginViewModel)
            {
                return LoginView;
            }
            else if (item is RegistrationViewModel)
            {
                return RegistrationView;
            }

            return LoginView;
        }
    }
}