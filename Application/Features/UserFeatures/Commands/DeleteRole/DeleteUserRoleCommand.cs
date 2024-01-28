using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public sealed record DeleteUserRoleCommand(int UserId, string RoleName) : IRequest<Response>;