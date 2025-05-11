
using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile
{
    public class AdminUpdateUserProfileDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
