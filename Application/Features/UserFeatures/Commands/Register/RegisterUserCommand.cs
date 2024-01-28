using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Register;

public sealed record RegisterUserCommand(
    string UserName,
    string Email,
    string Password)
    : ICreateCommand<UserViewModel>;