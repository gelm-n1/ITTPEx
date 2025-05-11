
using MediatR;

namespace ITTPEx.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesQuery : IRequest<List<GetAllRolesDto>>;
}
