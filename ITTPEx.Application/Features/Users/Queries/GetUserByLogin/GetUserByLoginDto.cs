
using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Application.Features.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginDto
    {
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
        public bool IsActive { get; init; }
    }
}
