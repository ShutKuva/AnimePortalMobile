using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimePortalMobile.Models.Db
{
    public class AnimeDescription : BaseEntity
    {
        public int LanguageId { get; set; }
        [Required]
        public Language Language { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public string Status { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Placement { get; set; } = string.Empty;
        public int AnimeId { get; set; }
    }
}
