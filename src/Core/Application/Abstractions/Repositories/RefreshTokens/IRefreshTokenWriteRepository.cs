using Application.Abstractions.Repositories.Common;
using Domain.Entities;

namespace Application.Abstractions.Repositories.RefreshTokens
{
    public interface IRefreshTokenWriteRepository : IWriteRepository<RefreshToken>
    {
    }
}
