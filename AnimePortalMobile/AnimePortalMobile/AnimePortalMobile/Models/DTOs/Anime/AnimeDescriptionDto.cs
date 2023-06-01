using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnimePortalMobile.Models.DTOs.Others;

namespace AnimePortalMobile.Models.DTOs.Anime
{
    public class AnimeDescriptionDto
    {
        [Required]
        public LanguageDto Language { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Placement { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();

    }
}
