using Application.Abstractions.Repositories.RefreshTokens;
using Domain.Entities;
using Persistence.Concrete.Repositories.Common;
using Persistence.Contexts;

namespace Persistence.Concrete.Repositories.RefreshTokens
{
    public class RefreshTokenWriteRepository : WriteRepository<RefreshToken>, IRefreshTokenWriteRepository
    {
        public RefreshTokenWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
