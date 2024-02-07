using Application.DTOs.Role;
using Application.Wrappers;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.DeleteRoleFromUser;

public sealed record DeleteRoleFromUserCommand : IRequest<Response>
{
    public int UserId { get; init; }
    public string RoleName { get; init; }

    public DeleteRoleFromUserCommand(DeleteRoleFromUserDto dto)
    {
        UserId = dto.UserId;
        RoleName = dto.RoleName;
    }
}