namespace Application.Auth;

public sealed record TokenModel(
    string AccessToken,
    DateTime Expires,
    string RefreshToken);