using Application.DTOs.Role;
using Application.Interfaces.Queries;

namespace Application.Features.RoleFeatures.Queries.GetById;

public sealed record GetRoleByIdQuery(int Id) : ISingleQuery<RoleViewModel>;