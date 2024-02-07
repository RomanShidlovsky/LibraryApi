using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<bool> AddRoleToUserAsync(int userId, int roleId, CancellationToken cancellationToken);
    Task<bool> DeleteRoleFromUserAsync(int userId, int roleId, CancellationToken cancellationToken);
}