
using ITTPEx.Domain.Enumerations;
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserProfile
{
    public record SelfUpdateUserProfileCommand : IRequest<SelfUpdateUserProfileDto>
    {
        public string? Name { get; init; }
        public Gender? Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
