using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Common.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
