using Application.Extensions;
using FluentValidation;

namespace Application.Features.BookFeatures.Commands.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
        RuleFor(b => b.ISBN.IsValidISBN()).Equal(true);
        RuleFor(b => b.Title).MaximumLength(100);
    }
}