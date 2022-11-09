using Domain.Entities;
using Persistence.Concrete.Repositories.Common;
using Persistence.Contexts;

namespace Persistence.Concrete.Repositories.RefreshTokens
{
    public class RefreshTokenReadRepository : ReadRepository<RefreshToken>
    {
        public RefreshTokenReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
