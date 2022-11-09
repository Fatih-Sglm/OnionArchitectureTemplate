using Application.Features.Auth.Dtos;

namespace Application.Abstractions.Services
{
    public interface IRefreshTokenService
    {
        Task AddRefreshToken(RefreshTokenDto refreshTokenDto);
    }
}
