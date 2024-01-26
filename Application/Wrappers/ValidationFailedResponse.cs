using Application.Interfaces;
using Domain.Errors;

namespace Application.Wrappers;

public class ValidationFailedResponse : Response, IValidationFailedResponse
{
    public ValidationFailedResponse(IEnumerable<Error> errors)
        : base(false, IValidationFailedResponse.ValidationError)
    {
        Errors = errors;
    }

    public IEnumerable<Error> Errors { get; }

    public static ValidationFailedResponse WithErrors(IEnumerable<Error> errors) => new(errors);
}