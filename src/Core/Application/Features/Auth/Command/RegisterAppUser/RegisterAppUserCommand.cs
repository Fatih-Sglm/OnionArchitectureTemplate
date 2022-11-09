using Application.Commons.Models.ResponseModels;
using Application.Features.Auth.Constant;
using Application.Features.Auth.Dtos;
using AutoMapper;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities.Common.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Command.RegisterAppUser
{
    public class RegisterAppUserCommand : RegisterAppUserDto, IRequest<CustomResponse<NoContentData>>
    {

        public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, CustomResponse<NoContentData>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;

            public RegisterAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<CustomResponse<NoContentData>> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
            {
                AppUser appUser = _mapper.Map<AppUser>(request);
                IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);
                if (result.Succeeded)
                    return CustomResponse<NoContentData>.SuccesWithOutData(AuthConstant.RegisterConst);
                throw new IdentityException(result.Errors);
            }
        }
    }
}
