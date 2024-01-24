using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Update;

public sealed record UpdateUserCommand(
    int Id,
    string Username,
    string Email)
    : IUpdateCommand<UserViewModel>;  