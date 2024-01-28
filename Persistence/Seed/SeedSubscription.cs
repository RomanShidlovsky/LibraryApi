using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Persistence.Seed;

public static class SeedSubscription
{
    public static void Add(IUnitOfWork unitOfWork)
    {
        var subscriptionRepository = unitOfWork.GetRepository<ISubscriptionRepository>();
        foreach (var subscription in SeedData.Subscriptions)
        {
            subscriptionRepository.Create(subscription);
        }

        unitOfWork.Save();
    }
}