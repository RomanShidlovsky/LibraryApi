using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class SubscriptionRepository(DataContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public async Task ReturnBook(int subscriptionId, CancellationToken cancellationToken)
    {
        var subscription = await GetEntitySet()
            .FirstOrDefaultAsync(s => s.Id == subscriptionId, cancellationToken);

        if (subscription != null) 
            subscription.IsActive = false;
    }
}