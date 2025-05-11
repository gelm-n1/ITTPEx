namespace ITTPEx.Application.Interfaces.Services.Authentication.Tokens
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(string userId, string roleName);
    }
}
