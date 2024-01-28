using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.UserFeatures.Commands.AddRole;

public class AddUserRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
    : IRequestHandler<AddUserRoleCommand, Response>
{
    public async Task<Response> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(request.RoleName);
        if (role == null)
            return Response.Failure(DomainErrors.Role.RoleNotFoundByName);
        
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return Response.Failure(DomainErrors.User.UserNotFoundById);

        var isInRole = await userManager.IsInRoleAsync(user, request.RoleName);
        if (isInRole)
            return Response.Failure(DomainErrors.User.AlreadyInRole);

        var result = await userManager.AddToRoleAsync(user, request.RoleName);
        
        return result.Succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.User.RoleNotAdded);
    }
}