﻿using System.ComponentModel.DataAnnotations;

namespace AnimePortalMobile.Models.DTOs.Jwt
{
    public class RegisterUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
