using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.UserFeatures.Commands.AddRole;

public sealed record AddUserRoleCommand(int UserId, string RoleName) : IRequest<Response>;