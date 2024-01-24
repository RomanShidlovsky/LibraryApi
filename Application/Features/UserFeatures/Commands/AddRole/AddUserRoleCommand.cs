using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.AddRole;

public sealed record AddUserRoleCommand(int UserId, int RoleId) : IUpdateCommand<bool>;