using Application.Features.Auth.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Common.Identity;

namespace Application.Features.Auth.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterAppUserDto, AppUser>();
            CreateMap<RefreshTokenDto, RefreshToken>();
        }
    }
}
