using Application.Interfaces;
using Domain.Errors;

namespace Application.Wrappers;

public class ValidationFailedResponse<T>: Response<T>, IValidationFailedResponse
{
    public IEnumerable<Error> Errors { get; }
    
    public ValidationFailedResponse(IEnumerable<Error> errors) 
        : base(default, false, IValidationFailedResponse.ValidationError)
    {
        Errors = errors;
    }

    public static ValidationFailedResponse<T> WithErrors(IEnumerable<Error> errors) => new(errors);
}