
using ITTPEx.Domain.Enumerations;
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public string Login { get; init; }
        public string Password { get; init; }
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
