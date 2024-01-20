namespace Application.Exceptions;

public class BadRequestException : Exception
{
    public string[] Errors { get; set; } = [];
    
    public BadRequestException(string message) : base(message)
    { }

    public BadRequestException(string[] errors) : base("Multiple errors occured. See error details.")
    {
        Errors = errors;
    }
}