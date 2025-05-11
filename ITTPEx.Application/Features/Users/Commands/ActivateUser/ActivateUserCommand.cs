
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.ActivateUser
{ 
    public record ActivateUserCommand(Guid Id) : IRequest<Unit>;
}
