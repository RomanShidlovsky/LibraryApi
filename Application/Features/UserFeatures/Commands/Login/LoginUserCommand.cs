using Application.Auth;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Login;

public sealed record LoginUserCommand(
    string UserName,
    string Password)
    : IUpdateCommand<TokenModel>;