using Application.Wrappers;
using Domain.Entities;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RoleFeatures.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
    : IRequestHandler<AddRoleToUserCommand, Response>
{
    public async Task<Response> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
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