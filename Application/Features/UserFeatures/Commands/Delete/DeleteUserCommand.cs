using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Delete;

public sealed record DeleteUserCommand(int Id) : IDeleteCommand<UserViewModel>; 