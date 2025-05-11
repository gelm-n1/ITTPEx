
using ITTPEx.Domain.Entities;

namespace ITTPEx.Application.Interfaces.Repositories.Authentication
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetActiveUsersAsync(CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetUsersOlderThan(int minAge, CancellationToken cancellationToken);
        Task<bool> ExistByLoginAsync(string login, CancellationToken cancellationToken);
        Task<string> GetLoginByUserId(Guid id, CancellationToken cancellationToken);
    }
}
