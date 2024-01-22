using FluentValidation;

namespace Application.Features.AuthorFeatures.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty();
        RuleFor(a => a.FirstName)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(a => a.LastName)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(a => a.FullName)
            .NotEmpty()
            .MaximumLength(100);
    }
}