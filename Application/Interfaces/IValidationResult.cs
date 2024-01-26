﻿using Domain.Errors;

namespace Application.Interfaces;

public interface IValidationFailedResponse
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "Validation error has been occurred",
        422);
    
    IEnumerable<Error> Errors { get; }
}