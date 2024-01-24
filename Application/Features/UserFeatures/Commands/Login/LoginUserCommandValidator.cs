using FluentValidation;

namespace Application.Features.UserFeatures.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(u => u.Password)
            .NotEmpty()
            .MaximumLength(64);
    }
}