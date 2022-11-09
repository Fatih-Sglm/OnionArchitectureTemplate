using Application.Commons.Models.LoginModels;
using Application.Features.Auth.Dtos;

namespace Application.Features.Auth.Command.LoginAppUser
{
    public class LoginAppUserReponse
    {
        public AccessToken AccessToken { get; set; }
        public RefreshTokenDto RefreshToken { get; set; }
    }
}
