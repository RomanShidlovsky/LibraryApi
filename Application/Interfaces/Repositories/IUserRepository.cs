using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> AddRoleAsync(int userId, int roleId, CancellationToken cancellationToken);
    Task<bool> DeleteRoleAsync(int userId, int roleId, CancellationToken cancellationToken);
}