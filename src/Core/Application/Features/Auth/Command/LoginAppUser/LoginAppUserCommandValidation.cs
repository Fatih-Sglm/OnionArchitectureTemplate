using Application.Features.Auth.Dtos;
using FluentValidation;

namespace Application.Features.Auth.Command.LoginAppUser
{
    public class LoginAppUserCommandValidation : AbstractValidator<LoginAppUserDto>
    {
        public LoginAppUserCommandValidation()
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty().NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
        }
    }
}
