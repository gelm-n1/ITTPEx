
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using ITTPEx.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ITTPEx.Infrastructure.Repositories.Authentication
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistByLoginAsync(string login, CancellationToken cancellationToken)
        {
            var normalizedLogin = login.ToLowerInvariant();
            return await _dbContext.Users.AnyAsync(u => u.Login == normalizedLogin, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync(CancellationToken cancellationToken)
        {

            return await _dbContext.Users
                .Where(u => u.RevokedOn == null)
                .Include(u => u.Role)
                .OrderBy(u => u.CreatedOn)
                .ToListAsync();
        }

        public async Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken)
        {
            var normalizedLogin = login.ToLowerInvariant();
            return await _dbContext.Users
                .FirstAsync(u => u.Login == normalizedLogin);
        }

        public async Task<string> GetLoginByUserId(Guid id, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstAsync(u => u.Id == id);
            return user.Login;
        }

        public async Task<IEnumerable<User>> GetUsersOlderThan(int minAge, CancellationToken cancellationToken)
        {
            var minBirthDate = DateTime.UtcNow.AddYears(-minAge - 1).AddDays(1);

            return await _dbContext.Users
                .Where(u => u.Birthday != null && u.Birthday <= minBirthDate)
                .Include(u => u.Role)
                .ToListAsync();
        }

        
    }
}
