using Domain.Entities.Common;
using Domain.Entities.Common.Identity;

namespace Domain.Entities;

public class RefreshToken : BaseEntity<int>
{
    public Guid AppUserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }
    public AppUser AppUser { get; set; }
}