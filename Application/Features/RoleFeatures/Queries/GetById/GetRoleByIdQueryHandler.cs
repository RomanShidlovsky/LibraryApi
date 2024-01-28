using Application.DTOs.Role;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RoleFeatures.Queries.GetById;

public class GetRoleByIdQueryHandler(
    RoleManager<Role> roleManager,
    IMapper mapper)
    : ISingleQueryHandler<GetRoleByIdQuery, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id.ToString());

        return role == null
            ? Response.Failure<RoleViewModel>(DomainErrors.Role.RoleNotFoundById) 
            : mapper.Map<RoleViewModel>(role);
    }
}