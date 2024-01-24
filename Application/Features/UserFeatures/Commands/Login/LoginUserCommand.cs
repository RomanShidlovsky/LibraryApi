using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Login;

public sealed record LoginUserCommand(string Username, string Password) : IUpdateCommand<string>;