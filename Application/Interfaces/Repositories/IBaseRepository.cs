using Domain.Common;

namespace Application.Interfaces.Repositories;

public interface IBaseRepository;

public interface IBaseRepository<T> : IBaseRepository
    where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> Get(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
    Task<bool> Exists(int id, CancellationToken cancellationToken);
}