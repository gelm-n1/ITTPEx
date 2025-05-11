
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserLogin
{
    public class AdminUpdateUserLoginCommand : IRequest<Unit>
    {
        public Guid UserId { get; init; }
        public string NewLogin { get; init; }
    }
}
