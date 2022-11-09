using Domain.Entities.Common;
using Domain.Entities.Common.Identity;

namespace Domain.Entities;

public class OperationClaim : BaseEntity<int>
{
    public OperationClaim()
    {
        Roles = new HashSet<AppRole>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AppRole> Roles { get; set; }
}