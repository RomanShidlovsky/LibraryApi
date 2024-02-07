using Application.Wrappers;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.DeleteRoleFromUser;

public sealed record DeleteRoleFromUserCommand(int UserId, string RoleName) : IRequest<Response>;