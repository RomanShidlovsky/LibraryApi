using FluentValidation;

namespace Application.Features.UserFeatures.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty();
        RuleFor(u => u.Username)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();
    }
}