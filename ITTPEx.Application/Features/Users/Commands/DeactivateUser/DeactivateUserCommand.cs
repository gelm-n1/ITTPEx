
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.DeactivateUser
{
    public record DeactivateUserCommand(Guid Id) : IRequest<Unit>;
}
