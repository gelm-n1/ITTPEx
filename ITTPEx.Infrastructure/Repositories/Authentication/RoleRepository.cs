
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using ITTPEx.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ITTPEx.Infrastructure.Repositories.Authentication
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken)
        {
            var normalizedName = name.ToLowerInvariant();
            return await _dbContext.Roles.AnyAsync(u => u.Name == normalizedName, cancellationToken);
        }

        public async Task<Role> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var normalizedName = name.ToLowerInvariant();
            return await _dbContext.Roles.FirstAsync(r => r.Name == normalizedName, cancellationToken);
        }
    }
}
