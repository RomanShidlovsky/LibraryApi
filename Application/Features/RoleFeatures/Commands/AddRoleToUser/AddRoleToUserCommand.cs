using Application.Wrappers;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.AddRoleToUser;

public sealed record AddRoleToUserCommand(int UserId, string RoleName) : IRequest<Response>;