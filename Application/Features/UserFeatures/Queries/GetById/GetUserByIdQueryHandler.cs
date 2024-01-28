using Application.DTOs.User;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.Queries.GetById;

public class GetUserByIdQueryHandler(UserManager<User> userManager, IMapper mapper)
    : ISingleQueryHandler<GetUserByIdQuery, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users
            .Include(u => u.Subscriptions)
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        
        if (user == null)
            return Response.Failure<UserViewModel>(DomainErrors.User.UserNotFoundById);
        
        var userRoles = await userManager.GetRolesAsync(user);

        var userViewModel = mapper.Map<UserViewModel>(user);
        userViewModel.Roles = userRoles;

        return userViewModel;
    }
}