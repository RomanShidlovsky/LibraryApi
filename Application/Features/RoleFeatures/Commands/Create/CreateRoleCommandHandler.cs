using Application.DTOs.Role;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RoleFeatures.Commands.Create;

public class CreateRoleCommandHandler(
    RoleManager<Role> roleManager,
    IMapper mapper)
    : ICreateCommandHandler<CreateRoleCommand, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(request.Name);
        if (role != null)
            return Response.Failure<RoleViewModel>(DomainErrors.Role.NameConflict);

        var newRole = mapper.Map<Role>(request);
        newRole.ConcurrencyStamp = Guid.NewGuid().ToString();

        var result = await roleManager.CreateAsync(newRole);

        return result.Succeeded
            ? mapper.Map<RoleViewModel>(newRole)
            : Response.Failure<RoleViewModel>(new Error(
                result.Errors.First().Code,
                result.Errors.First().Description,
                400));
    }
}