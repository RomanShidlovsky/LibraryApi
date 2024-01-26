using FluentValidation;

namespace Application.Features.RoleFeatures.Commands.Update;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters.");
    }
}