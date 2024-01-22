using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;

public class UnitOfWork(DataContext context, IServiceProvider serviceProvider) : IUnitOfWork
{
    private bool _disposed = false;

    public TRepository GetRepository<TRepository>() where TRepository : IBaseRepository
    {
        return serviceProvider.GetRequiredService<TRepository>();
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public Task SaveAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}