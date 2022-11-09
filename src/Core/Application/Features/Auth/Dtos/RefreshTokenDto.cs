namespace Application.Features.Auth.Dtos
{
    public class RefreshTokenDto
    {
        public Guid AppUserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; }
    }
}
