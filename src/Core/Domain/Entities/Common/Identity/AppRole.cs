using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Common.Identity
{
    public class AppRole : IdentityRole<Guid>, IEntity
    {
        public ICollection<OperationClaim> Claims { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
