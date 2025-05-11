
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserPassword
{
    public record SelfUpdateUserPasswordCommand : IRequest<Unit>
    {
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
    }
}
