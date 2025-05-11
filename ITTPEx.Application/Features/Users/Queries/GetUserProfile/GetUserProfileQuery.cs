
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUserProfile
{
    public record GetUserProfileQuery: IRequest<GetUserProfileDto>
    {
        public string Password { get; init; }
    }
}
