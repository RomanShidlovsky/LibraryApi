using FluentValidation;

namespace Application.Features.UserFeatures.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(u => u.Password)
            .NotEmpty()
            .MaximumLength(64);
    }
}