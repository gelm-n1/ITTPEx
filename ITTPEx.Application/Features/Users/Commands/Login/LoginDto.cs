
namespace ITTPEx.Application.Features.Users.Commands.Login
{
    public class LoginDto
    {
        public Guid UserId { get; init; }
        public string Role { get; init; }
        public string Token { get; init; }

    }
}
