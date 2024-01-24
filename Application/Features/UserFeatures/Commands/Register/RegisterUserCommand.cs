using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Username,
    string Password)
    : ICreateCommand<UserViewModel>;