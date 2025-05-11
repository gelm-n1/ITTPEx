
using MediatR;

namespace ITTPEx.Application.Features.Roles.Queries.GetRoleById
{
    public record GetRoleByIdQuery(Guid Id) : IRequest<GetRoleByIdDto>;
}
