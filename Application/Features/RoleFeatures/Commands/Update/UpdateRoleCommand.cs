using Application.DTOs.Role;
using Application.Interfaces.Commands;

namespace Application.Features.RoleFeatures.Commands.Update;

public sealed record UpdateRoleCommand(
    int Id,
    string Name) 
    : IUpdateCommand<RoleViewModel>;