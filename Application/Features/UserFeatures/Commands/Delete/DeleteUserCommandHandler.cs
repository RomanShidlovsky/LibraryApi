using Application.DTOs.User;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.UserFeatures.Commands.Delete;

public class DeleteUserCommandHandler(
    UserManager<User> userManager,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteUserCommand, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
            return Response.Failure<UserViewModel>(DomainErrors.User.UserNotFoundById);

        var result = await userManager.DeleteAsync(user);

        return result.Succeeded
            ? mapper.Map<UserViewModel>(user)
            : Response.Failure<UserViewModel>(new Error(
                result.Errors.First().Code,
                result.Errors.First().Description,
                400));
    }
}