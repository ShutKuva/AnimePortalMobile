﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnimePortalMobile.Models.DTOs.Others;

namespace AnimePortalMobile.Models.DTOs.Anime
{
    public class AnimeDetailed
    {
        [Required]
        public AnimeDescriptionDto AnimeDescription { get; set; }
        public ICollection<PhotoDto> Screenshots { get; set; } = new List<PhotoDto>();
        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();
        public string Poster { get; set; } = string.Empty;
        public string Studio { get; set; } = string.Empty;
        public float Rating { get; set; } = 0.0f;

    }
}
