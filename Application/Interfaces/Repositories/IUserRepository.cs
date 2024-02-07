using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}