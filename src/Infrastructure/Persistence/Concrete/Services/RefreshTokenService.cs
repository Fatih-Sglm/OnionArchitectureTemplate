using Application.Abstractions.Repositories.RefreshTokens;
using Application.Abstractions.Services;
using Application.Features.Auth.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Concrete.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
        private readonly IMapper _mapper;
        public RefreshTokenService(IRefreshTokenWriteRepository refreshTokenWriteRepository, IMapper mapper)
        {
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
            _mapper = mapper;
        }

        public async Task AddRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            RefreshToken refreshToken = _mapper.Map<RefreshToken>(refreshTokenDto);
            await _refreshTokenWriteRepository.AddAsync(refreshToken);
            await _refreshTokenWriteRepository.SaveChangesAsync();
        }
    }
}
