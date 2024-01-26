using FluentValidation;

namespace Application.Features.UserFeatures.Commands.Delete;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("User Id is required.");
    }
}