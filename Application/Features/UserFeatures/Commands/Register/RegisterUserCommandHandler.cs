using Application.DTOs.User;
using Application.Interfaces.Commands;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.UserFeatures.Commands.Register;

public class RegisterUserCommandHandler(UserManager<User> userManager, IMapper mapper)
    : ICreateCommandHandler<RegisterUserCommand, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userManager.FindByNameAsync(request.UserName);
        if (existingUser != null)
            return Response.Failure<UserViewModel>(DomainErrors.User.UsernameConflict);

        var user = mapper.Map<User>(request);
        user.SecurityStamp = Guid.NewGuid().ToString();

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Response.Failure<UserViewModel>(new Error(
                result.Errors.First().Code,
                result.Errors.First().Description, 
                400));

        await userManager.AddToRoleAsync(user, Roles.Client.ToString());
        
        return mapper.Map<UserViewModel>(user);
    }
}