using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Register;

public sealed record RegisterUserCommand : ICreateCommand<UserViewModel>
{
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public RegisterUserCommand(RegisterUserDto dto)
    {
        UserName = dto.UserName;
        Email = dto.Email;
        Password = dto.Password;
    }
}