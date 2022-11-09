using Application.Features.Auth.Command.LoginAppUser;
using Application.Features.Auth.Command.RegisterAppUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthContoller : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAppUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterAppUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
