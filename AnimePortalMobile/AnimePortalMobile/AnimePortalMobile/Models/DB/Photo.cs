using System.ComponentModel.DataAnnotations;
using AnimePortalMobile.Models.Enums;

namespace AnimePortalMobile.Models.Db
{
    public class Photo : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [Required]
        public PhotoTypes PhotoType { get; set; }
    }
}
