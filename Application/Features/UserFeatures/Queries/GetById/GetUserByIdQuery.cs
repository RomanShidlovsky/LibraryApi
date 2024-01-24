using Application.DTOs.User;
using Application.Interfaces.Queries;

namespace Application.Features.UserFeatures.Queries.GetById;

public sealed record GetUserByIdQuery(int Id) : ISingleQuery<UserViewModel>;
