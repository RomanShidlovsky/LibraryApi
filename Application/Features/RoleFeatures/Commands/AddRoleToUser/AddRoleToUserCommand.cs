using Application.DTOs.Role;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.AddRoleToUser;

public sealed record AddRoleToUserCommand : IRequest<Response>
{
    public int UserId { get; init; }
    public string RoleName { get; init; }

    public AddRoleToUserCommand(AddRoleToUserDto dto)
    {
        UserId = dto.UserId;
        RoleName = dto.RoleName;
    }
}