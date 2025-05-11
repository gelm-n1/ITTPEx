

using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserLogin
{
    public record SelfUpdateUserLoginCommand(string Login) : IRequest<Unit>;
}
