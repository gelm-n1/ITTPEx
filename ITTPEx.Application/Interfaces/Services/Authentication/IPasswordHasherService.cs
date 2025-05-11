namespace ITTPEx.Application.Interfaces.Services.Authentication
{
    public interface IPasswordHasherService
    {
        string GeneratePassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
