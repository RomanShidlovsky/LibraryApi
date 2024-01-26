using FluentValidation;

namespace Application.Features.UserFeatures.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");
        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(64);
    }
}