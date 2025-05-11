
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.DeleteRole
{
    public record DeleteRoleCommand(Guid Id) : IRequest<Unit>;
}
