
using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileDto
    {
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
