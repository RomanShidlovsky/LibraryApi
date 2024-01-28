using Application.DTOs.Role;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RoleFeatures.Commands.Delete;

public class DeleteRoleCommandHandler(
    RoleManager<Role> roleManager,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteRoleCommand, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id.ToString());
        if (role == null)
            return Response.Failure<RoleViewModel>(DomainErrors.Role.RoleNotFoundById);

        var result = await roleManager.DeleteAsync(role);

        return result.Succeeded
            ? mapper.Map<RoleViewModel>(role)
            : Response.Failure<RoleViewModel>(new Error(
                result.Errors.First().Code,
                result.Errors.First().Description,
                400));
    }
}
    