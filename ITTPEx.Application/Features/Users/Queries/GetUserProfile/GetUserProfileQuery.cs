
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUserProfile
{
    public record GetUserProfileQuery(string Password): IRequest<GetUserProfileDto>;
}
