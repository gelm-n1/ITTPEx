

using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.Login
{
    public record LoginCommand(string Login, string Password) : IRequest<LoginDto>;
}
