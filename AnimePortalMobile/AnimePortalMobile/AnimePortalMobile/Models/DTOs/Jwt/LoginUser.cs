using System.ComponentModel.DataAnnotations;

namespace AnimePortalMobile.Models.DTOs.Jwt
{
    public class LoginUser
    {
        [Required]
        public string NameOrEmail { get; set; } = string.Empty;

        [Required] 
        public string Password { get; set; } = string.Empty;
    }
}