using FluentValidation;

namespace Application.Features.BookFeatures.Commands.Delete;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(b => b.Id)
            .NotEmpty().WithMessage("The Id field is required");
    }
}