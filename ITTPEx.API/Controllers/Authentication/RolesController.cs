using ITTPEx.API.Common;
using ITTPEx.Application.Features.Roles.Commands.CreateRole;
using ITTPEx.Application.Features.Roles.Commands.DeleteRole;
using ITTPEx.Application.Features.Roles.Commands.UpdateRoleName;
using ITTPEx.Application.Features.Roles.Queries.GetAllRoles;
using ITTPEx.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ITTPEx.API.Controllers.Authentication
{
    [Authorize(Roles = "admin")]
    public class RolesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        
        public async Task<ActionResult<CreateRoleDto>> CreateRole(CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllRolesDto>>> GetAllRoles()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRoleByIdDto>> GetRoleById(Guid id)
        {
            return await _mediator.Send(new GetRoleByIdQuery(id));
        }

        [HttpPatch("name")]
        public async Task<ActionResult> UpdateRoleName(UpdateRoleNameCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            await _mediator.Send(new DeleteRoleCommand(id));
            return NoContent();
        }
    }
}
