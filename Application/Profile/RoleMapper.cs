using Application.DTOs.Role;
using Application.Features.RoleFeatures.Commands.Create;
using Application.Features.RoleFeatures.Commands.Update;
using Domain.Entities;

namespace Application.Profile;

public class RoleMapper : AutoMapper.Profile
{
    public RoleMapper()
    {
        CreateMap<CreateRoleCommand, Role>();
        CreateMap<UpdateRoleCommand, Role>();
        CreateMap<Role, RoleViewModel>()
            .ReverseMap();
    }
}