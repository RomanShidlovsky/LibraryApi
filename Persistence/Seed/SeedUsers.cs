﻿using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Seed;

public static class SeedUsers
{
    public static async Task Add(UserManager<User> userManager)
    {
        var roles = Enum.GetNames(typeof(Roles));
        foreach (var role in roles)
        {
            var user = await userManager.FindByNameAsync(role);
            if (user != null)
                continue;

            user = new User()
            {
                UserName = role
            };
            var password = $"{role}1!";

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception($"Failed to create {role} user: {string.Join(", ", errors)}");
            }
        }
    }
}