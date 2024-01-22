using Application.DTOs.Role;
using Application.Interfaces.Commands;

namespace Application.Features.RoleFeatures.Commands.Create;

public sealed record CreateRoleCommand(string Name) : ICreateCommand<RoleViewModel>;