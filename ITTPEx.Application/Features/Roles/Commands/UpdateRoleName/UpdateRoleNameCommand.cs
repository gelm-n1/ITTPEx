
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.UpdateRoleName
{
    public record UpdateRoleNameCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public string NewName { get; init; }
    }
}
