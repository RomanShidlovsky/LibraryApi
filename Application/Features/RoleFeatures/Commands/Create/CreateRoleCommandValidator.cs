using FluentValidation;

namespace Application.Features.RoleFeatures.Commands.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters.");
    }
}