using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("The Id field is required.");
        RuleFor(a => a.FirstName)
            .NotEmpty().WithMessage("The FirstName field is required.")
            .MaximumLength(25).WithMessage("The FirstName must not exceed 25 characters.");
        RuleFor(a => a.LastName)
            .NotEmpty().WithMessage("The LastName field is required.")
            .MaximumLength(25).WithMessage("The LastName must not exceed 25 characters.");
        RuleFor(a => a.FullName)
            .MaximumLength(100).WithMessage("The FullName must not exceed 100 characters.");
    }
}