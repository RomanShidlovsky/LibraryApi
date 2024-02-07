using FluentValidation;

namespace Application.Features.RoleFeatures.Commands.DeleteRoleFromUser;

public class DeleteRoleFromUserCommandValidator : AbstractValidator<DeleteRoleFromUserCommand>
{
    public DeleteRoleFromUserCommandValidator()
    {
        RuleFor(c => c.RoleName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters.");
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}