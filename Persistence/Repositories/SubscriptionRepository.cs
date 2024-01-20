using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SubscriptionRepository(DataContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository;