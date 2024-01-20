using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException() : Exception("One or more validation failures have occurred.")
{
    public List<ErrorModel> Errors { get; } = [];

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(new ErrorModel(failure.PropertyName, failure.ErrorMessage));
        }
    }
}

public sealed record ErrorModel(string PropertyName, string ErrorMessage);
