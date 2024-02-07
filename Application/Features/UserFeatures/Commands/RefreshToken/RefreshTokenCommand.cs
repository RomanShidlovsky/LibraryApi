using Application.Auth;
using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.RefreshToken;

public sealed record RefreshTokenCommand : IUpdateCommand<TokenModel>
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }

    public RefreshTokenCommand(RefreshTokenDto dto)
    {
        AccessToken = dto.AccessToken;
        RefreshToken = dto.RefreshToken;
    }
}