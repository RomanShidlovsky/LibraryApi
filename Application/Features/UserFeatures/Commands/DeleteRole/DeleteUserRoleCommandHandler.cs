using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandHandler(UserManager<User> userManager)
    : IRequestHandler<DeleteUserRoleCommand, Response>
{
    public async Task<Response> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return Response.Failure(DomainErrors.User.UserNotFoundById);

        var result = await userManager.RemoveFromRoleAsync(user, request.RoleName);

        return result.Succeeded
            ? Response.Success()
            : Response.Failure(new Error(
                result.Errors.First().Code,
                result.Errors.First().Description, 
                400));
    }
}