
using ITTPEx.API.Common;
using ITTPEx.Application.Features.Users.Commands.ActivateUser;
using ITTPEx.Application.Features.Users.Commands.AdminUpdateUserLogin;
using ITTPEx.Application.Features.Users.Commands.AdminUpdateUserPassword;
using ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile;
using ITTPEx.Application.Features.Users.Commands.CreateUser;
using ITTPEx.Application.Features.Users.Commands.DeactivateUser;
using ITTPEx.Application.Features.Users.Commands.DeleteUser;
using ITTPEx.Application.Features.Users.Queries.GetAllActiveUsers;
using ITTPEx.Application.Features.Users.Queries.GetUserByLogin;
using ITTPEx.Application.Features.Users.Queries.GetUsersOlderThan;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITTPEx.API.Controllers.Authentication
{
    [Authorize(Roles = "admin")]
    public class AdminUsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AdminUsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<GetAllActiveUsersDto>>> GetActiveUsers()
        {
            return await _mediator.Send(new GetAllActiveUsersQuery());
        }

        [HttpGet("login")]
        public async Task<ActionResult<GetUserByLoginDto>> GetUserByLogin([FromQuery]string login)
        {
            return await _mediator.Send(new GetUserByLoginQuery(login));
        }

        [HttpGet("age/{minAge}")]
        public async Task<ActionResult<List<GetUsersOlderThanDto>>> GetUsersOlderThan(int minAge)
        {
            return await _mediator.Send(new GetUsersOlderThanQuery(minAge));
        }
         
        [HttpPatch("profile")]
        public async Task<ActionResult<AdminUpdateUserProfileDto>> UpdateUserProfile(AdminUpdateUserProfileCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPatch("password")]
        public async Task<ActionResult> UpdateUserPassword(AdminUpdateUserPasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("login")]
        public async Task<ActionResult> UpdateUserLogin(AdminUpdateUserLoginCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("activate/{id}")]
        public async Task<ActionResult> ActivateUser(Guid id)
        {
            await _mediator.Send(new ActivateUserCommand(id));
            return NoContent();
        }

        [HttpPatch("deactivate/{id}")]
        public async Task<ActionResult> DeactivateUser(Guid id)
        {
            await _mediator.Send(new DeactivateUserCommand(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
        
    }
}
