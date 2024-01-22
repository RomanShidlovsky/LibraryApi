using Application.DTOs.Role;
using Application.Interfaces.Queries;

namespace Application.Features.RoleFeatures.Queries.GetAll;

public sealed record GetAllRolesQuery() : IQuery<IEnumerable<RoleViewModel>>;