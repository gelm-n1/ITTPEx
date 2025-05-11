
using ITTPEx.Domain.Entities;

namespace ITTPEx.Application.Interfaces.Repositories.Authentication
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken);
    }
}
