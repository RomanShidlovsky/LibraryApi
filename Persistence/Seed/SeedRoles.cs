using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Seed;

public static class SeedRoles
{
    public static async Task Add(RoleManager<Role> roleManager)
    {
        var roles = Enum.GetNames(typeof(Roles));

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new Role { Name = role } );
            }
        }
    }
}