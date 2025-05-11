
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserPassword
{
    public record AdminUpdateUserPasswordCommand() : IRequest<Unit>
    {
        public Guid UserId { get; init; }
        public string NewPassword { get; init; }
    }
}
