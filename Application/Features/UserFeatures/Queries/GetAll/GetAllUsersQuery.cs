using Application.DTOs.User;
using Application.Interfaces.Queries;

namespace Application.Features.UserFeatures.Queries.GetAll;

public sealed record GetAllUsersQuery : IQuery<IEnumerable<UserViewModel>>;