
using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserProfile
{
    public class SelfUpdateUserProfileDto
    {
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
