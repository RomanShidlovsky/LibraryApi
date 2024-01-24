using Application.Interfaces.Repositories;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    TRepository GetRepository<TRepository>() where TRepository : IBaseRepository;
    void Save();
    Task SaveAsync(CancellationToken cancellationToken);
}