using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.Commons.Models.LoginModels;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Domain.Entities.Common.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Concrete.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly string? IpAdress;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenHelper tokenHelper,
            AuthBusinessRules authBusinessRules, IHttpContextAccessor httpContextAccessor, IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
            IpAdress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            _refreshTokenService = refreshTokenService;
        }

        public async Task<(AccessToken, RefreshTokenDto)> LoginAsync(LoginAppUserDto logindto)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(logindto.UserNameOrEmail);
            appUser ??= await _userManager.FindByNameAsync(logindto.UserNameOrEmail);
            await _authBusinessRules.CannotBeNull(appUser);
            await _authBusinessRules.CheckPassword(appUser, logindto.Password);
            AccessToken accessToken = await _tokenHelper.CreateToken(appUser);
            RefreshTokenDto refreshTokenDto = await _tokenHelper.CreateRefreshToken(appUser, IpAdress, accessToken.Expiration);
            await _refreshTokenService.AddRefreshToken(refreshTokenDto);
            return (accessToken, refreshTokenDto);
        }
    }
}
