namespace Application.DTOs.User;

public sealed record LoginUserDto(
    string UserName,
    string Password);