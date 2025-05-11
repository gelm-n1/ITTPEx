
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUsersOlderThan
{
    public record GetUsersOlderThanQuery(int minAge) : IRequest<List<GetUsersOlderThanDto>>;
}
