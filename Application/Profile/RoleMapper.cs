using Application.DTOs.Role;
using Application.Features.RoleFeatures.Commands.Create;
using Domain.Entities;

namespace Application.Profile;

public class RoleMapper : AutoMapper.Profile
{
    public RoleMapper()
    {
        CreateMap<CreateRoleCommand, Role>();
        CreateMap<Role, RoleViewModel>()
            .ReverseMap();
    }
}