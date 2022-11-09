using Application.Abstractions.Services;
using Application.Commons.Models.LoginModels;
using Application.Commons.Models.ResponseModels;
using Application.Features.Auth.Dtos;
using MediatR;

namespace Application.Features.Auth.Command.LoginAppUser
{
    public class LoginAppUserCommand : IRequest<CustomResponse<LoginAppUserReponse>>
    {
        public LoginAppUserDto LoginDto { get; set; }

        public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, CustomResponse<LoginAppUserReponse>>
        {
            private readonly IAuthService _authService;

            public LoginAppUserCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<CustomResponse<LoginAppUserReponse>> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
            {
                (AccessToken accessToken, RefreshTokenDto refreshToken) = await _authService.LoginAsync(request.LoginDto);
                return CustomResponse<LoginAppUserReponse>.SuccesWithData(new() { AccessToken = accessToken, RefreshToken = refreshToken });
            }
        }
    }
}
