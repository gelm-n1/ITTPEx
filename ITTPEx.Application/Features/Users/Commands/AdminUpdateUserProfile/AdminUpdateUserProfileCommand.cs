
using ITTPEx.Domain.Enumerations;
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile
{
    public record AdminUpdateUserProfileCommand : IRequest<AdminUpdateUserProfileDto>
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public Gender? Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
