using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Seed;

public class SeedInitializer(IServiceProvider serviceProvider)
{
    public async Task Init()
    {
        var dataContext = serviceProvider.GetRequiredService<DataContext>();
        
        await SeedRoles.Add(serviceProvider.GetRequiredService<RoleManager<Role>>());
        await SeedUsers.Add(serviceProvider.GetRequiredService<UserManager<User>>());
        if (!dataContext.Subscriptions.Any())
        {
            SeedSubscription.Add(serviceProvider.GetRequiredService<IUnitOfWork>());
        }
    }
}