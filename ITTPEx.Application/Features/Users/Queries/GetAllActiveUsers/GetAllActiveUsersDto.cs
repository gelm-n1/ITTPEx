using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Application.Features.Users.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersDto
    {
        public Guid Id { get; init; }
        public string Login { get; init; }
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? Birthday { get; init; }
        public string RoleName { get; init; }
    }
}
