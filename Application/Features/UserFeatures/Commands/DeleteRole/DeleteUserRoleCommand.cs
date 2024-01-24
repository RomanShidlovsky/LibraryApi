using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public sealed record DeleteUserRoleCommand(int UserId, int RoleId) : IUpdateCommand<bool>;