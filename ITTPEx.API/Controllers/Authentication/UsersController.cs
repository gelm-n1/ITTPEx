using ITTPEx.API.Common;
using ITTPEx.Application.Features.Users.Commands.SelfUpdateUserLogin;
using ITTPEx.Application.Features.Users.Commands.SelfUpdateUserPassword;
using ITTPEx.Application.Features.Users.Commands.SelfUpdateUserProfile;
using ITTPEx.Application.Features.Users.Queries.GetUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITTPEx.API.Controllers.Authentication
{
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost("me")]
        public async Task<ActionResult<GetUserProfileDto>> GetUserByLoginAndPassword(GetUserProfileQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPatch("me/profile")]
        public async Task<ActionResult<SelfUpdateUserProfileDto>> UpdateUserProfile(SelfUpdateUserProfileCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPatch("me/password")]
        public async Task<ActionResult> UpdateUserPassword(SelfUpdateUserPasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("me/login")]
        public async Task<ActionResult> UpdateUserLogin(SelfUpdateUserLoginCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
