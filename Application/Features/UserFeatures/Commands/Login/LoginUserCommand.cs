using Application.Auth;
using Application.DTOs.User;
using Application.Interfaces.Commands;

namespace Application.Features.UserFeatures.Commands.Login;

public sealed record LoginUserCommand : IUpdateCommand<TokenModel>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public LoginUserCommand(LoginUserDto dto)
    {
        UserName = dto.UserName;
        Password = dto.Password;
    }
}