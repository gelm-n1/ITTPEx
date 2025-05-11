
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetAllActiveUsers
{
    public record GetAllActiveUsersQuery() : IRequest<List<GetAllActiveUsersDto>>;
}
