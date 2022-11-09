using Application.Commons.Models.LoginModels;
using Application.Features.Auth.Dtos;

namespace Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<(AccessToken, RefreshTokenDto)> LoginAsync(LoginAppUserDto logindto);
    }
}
