using Application.DTOs.Role;
using Application.Interfaces.Commands;

namespace Application.Features.RoleFeatures.Commands.Delete;

public sealed record DeleteRoleCommand(int Id) : IDeleteCommand<RoleViewModel>;
