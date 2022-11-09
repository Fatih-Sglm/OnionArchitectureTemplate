using Application.Commons.Models.LoginModels;
using Application.Features.Auth.Dtos;
using Domain.Entities.Common.Identity;

namespace Application.Abstractions.Token;

public interface ITokenHelper
{
    Task<RefreshTokenDto> CreateRefreshToken(AppUser user, string ipAddress, DateTime expiration);
    Task<AccessToken> CreateToken(AppUser appUser);
}