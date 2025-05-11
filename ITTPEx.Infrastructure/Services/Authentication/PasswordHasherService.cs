using ITTPEx.Application.Interfaces.Services.Authentication;

namespace ITTPEx.Infrastructure.Services.Authentication
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public string GeneratePassword(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
