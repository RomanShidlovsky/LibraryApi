namespace Application.DTOs.User;

public sealed record RegisterUserDto(
    string UserName,
    string Email,
    string Password);