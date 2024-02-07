using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task ReturnBook(int subscriptionId, CancellationToken cancellationToken);
}