using Application.Auth;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.RefreshToken;

public sealed record RefreshTokenCommand(string AccessToken, string RefreshToken)
    : IUpdateCommand<TokenModel>;