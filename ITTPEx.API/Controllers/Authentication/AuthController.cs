using ITTPEx.API.Common;
using ITTPEx.Application.Features.Users.Commands.Login;
using ITTPEx.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ITTPEx.API.Controllers.Authentication
{
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserDto>> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login(LoginCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
