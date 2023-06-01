using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimePortalMobile.Models.Db
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<AnimeDescription> AnimeDescriptions { get; set; } = new List<AnimeDescription>();
    }
}
