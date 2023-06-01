namespace AnimePortalMobile.Models.DTOs.Jwt
{
    public class JwtUserDto : JwtOnlyTokenDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}