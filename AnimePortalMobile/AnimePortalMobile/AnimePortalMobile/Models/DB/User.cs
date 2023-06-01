using System;
using AnimePortalMobile.Models.Enums;

namespace AnimePortalMobile.Models.Db
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string RefreshToken { get; set; } = String.Empty;
        public DateTime RefreshTokenExpires { get; set; }
        public Roles Roles { get; set; }
    }
}