using Application.Abstractions.Rules;
using Application.Features.Auth.Constant;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities.Common.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override Task CannotBeNull<T>(T item)
        {
            if (item is null)
                throw new NotFoundException(AuthConstant.UserNotFound);
            return Task.CompletedTask;
        }
        public async Task CheckPassword(AppUser appUser, string password)
        {
            bool IsPasswordCorrect = await _userManager.CheckPasswordAsync(appUser, password);
            if (!IsPasswordCorrect)
                throw new BusinessException(AuthConstant.WrongPassword);
            return;
        }
    }
}
