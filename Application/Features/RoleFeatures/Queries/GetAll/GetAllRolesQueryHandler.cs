using Application.DTOs.Role;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RoleFeatures.Queries.GetAll;

public class GetAllRolesQueryHandler(
    RoleManager<Role> roleManager,
    IMapper mapper) 
    : IQueryHandler<GetAllRolesQuery, IEnumerable<RoleViewModel>>
{
    public async Task<Response<IEnumerable<RoleViewModel>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var rolesList = await roleManager.Roles.ToListAsync(cancellationToken);

        return mapper.Map<List<RoleViewModel>>(rolesList);
    }
}