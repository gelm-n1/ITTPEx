
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand : IRequest<CreateRoleDto>
    {
        public string Name { get; init; }
    }
}
