using System;
using AnimePortalMobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace AnimePortalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogView
    {
        public CatalogViewModel ViewModel { get; set; }

        public CatalogView(CatalogViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;

            BindingContext = viewModel;

            ViewModel.Load.Execute("");
        }
    }
}