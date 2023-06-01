using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimePortalMobile.Abstractions;
using AnimePortalMobile.Constants;
using AnimePortalMobile.Models.DTOs.Anime;
using BLL.ApiClient;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AnimePortalMobile.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        private ObservableCollection<AnimeDetailed> _animePreview;
        public ObservableCollection<AnimeDetailed> AnimePreviews
        {
            get => _animePreview;
            set => SetField(ref _animePreview, value);
        }

        public ICommand Load { get; }

        public CatalogViewModel(AnimePortalApiClient apiClient, ISaveHandler<string, string> saveHandler) : base(apiClient, saveHandler)
        {
            Load = new AsyncCommand(LoadMethod);
        }

        private async Task LoadMethod()
        {
            IEnumerable<AnimeDetailed> animes = await _apiClient.GetAsync<string, IEnumerable<AnimeDetailed>>(
                "/api/anime/en/detailed/Top",
                null,
                null
                );

            AnimePreviews = animes == null ? AnimePreviews : new ObservableCollection<AnimeDetailed>(animes);
        }
    }
}