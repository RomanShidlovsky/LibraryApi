using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepository(DataContext context) : BaseRepository<User>(context), IUserRepository
{
    protected override IQueryable<User> GetEntitySet()
    {
        return Context.Set<User>()
            .Include(u => u.Roles)
            .Include(u => u.Subscriptions);
    }
    
    public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return GetEntitySet()
            .SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task<bool> AddRoleAsync(int userId, int roleId, CancellationToken cancellationToken)
    {
        var user = await Context.Set<User>()
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (user == null)
            return false;

        if (!user.Roles.Any(r => r.Id == roleId))
        {
            var role = await Context.Set<Role>()
                .FindAsync(roleId, cancellationToken);

            if (role == null)
                return false;
            
            user.Roles.Add(role);
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteRoleAsync(int userId, int roleId, CancellationToken cancellationToken)
    {
        var user = await Context.Set<User>()
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (user == null)
            return false;

        var role = user.Roles.SingleOrDefault(r => r.Id == roleId);

        if (role == null)
            return false;

        return user.Roles.Remove(role);

    }
}