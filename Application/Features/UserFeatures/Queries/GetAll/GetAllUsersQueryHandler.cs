using Application.DTOs.User;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.Queries.GetAll;

public class GetAllUsersQueryHandler(
    UserManager<User> userManager,
    IMapper mapper)
    : IQueryHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
{
    public async Task<Response<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var usersList = await userManager.Users.Include(u => u.Subscriptions).ToListAsync(cancellationToken);
        var userViewModels = mapper.Map<List<UserViewModel>>(usersList);

        for (var i = 0; i < usersList.Count; i++)
        {
            userViewModels[i].Roles = await userManager.GetRolesAsync(usersList[i]);
        }
        
        return userViewModels;
    }
}