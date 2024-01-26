using Application.Helpers;
using FluentValidation;

namespace Application.Features.BookFeatures.Commands.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.Id)
            .NotEmpty().WithMessage("The Id field is required.");;
        RuleFor(b => b.ISBN)
            .Must(IsbnHelper.IsValidIsbn).WithMessage("Invalid ISBN.");
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("The Title field is required.")
            .MaximumLength(100).WithMessage("The Title must not exceed 100 characters.");
    }
}