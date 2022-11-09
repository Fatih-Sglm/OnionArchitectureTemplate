using Application.Abstractions.Token;
using Application.Commons.Models.LoginModels;
using Application.Extensions.ClamiExtensions;
using Application.Features.Auth.Dtos;
using Domain.Entities.Common.Identity;
using Infrastructure.Encryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Dtos = Application.Features.Auth.Dtos;
namespace Infrastructure.Concrete.Token;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly Application.Commons.Models.LoginModels.TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public JwtHelper(IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<Application.Commons.Models.LoginModels.TokenOptions>();
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AccessToken> CreateToken(AppUser user)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtSecurityToken jwt = await CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    public async Task<RefreshTokenDto> CreateRefreshToken(AppUser user, string ipAddress, DateTime expiration)
    {
        RefreshTokenDto refreshToken = new()
        {
            AppUserId = user.Id,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = expiration.AddMinutes(_tokenOptions.RefreshTokenExpiration),
            CreatedByIp = ipAddress
        };

        return await Task.FromResult(refreshToken);
    }

    public async Task<JwtSecurityToken> CreateJwtSecurityToken(Application.Commons.Models.LoginModels.TokenOptions tokenOptions, AppUser user,
                                                   SigningCredentials signingCredentials)
    {
        JwtSecurityToken jwt = new(
            tokenOptions.Issuer,
            tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: await SetClaims(user, await _userManager.GetRolesAsync(user)),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private async Task<IEnumerable<Claim>> SetClaims(AppUser user, IList<string> roles)
    {


        List<Claim> claims = new();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddRoles(await GetUserRoleClaims(roles));
        return claims;
    }

    private async Task<string[]> GetUserRoleClaims(IList<string> roles)
    {
        List<string> roleClaims = new();
        foreach (var item in roles)
        {
            AppRole appRole = await _roleManager.FindByNameAsync(item);
            roleClaims.AddRange(appRole.Claims.Select(c => c.Name));
        }

        return roleClaims.ToArray();
    }
}