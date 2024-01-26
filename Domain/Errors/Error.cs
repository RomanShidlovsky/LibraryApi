namespace Domain.Errors;

public class Error
{
    public static readonly Error None = new(string.Empty, string.Empty, 0);
    
    public string Code { get; }
    public string Message { get; }
    public int? ErrorStatusCode { get; }

    public Error(string code, string message, int? errorStatusCode = 500)
    {
        Code = code;
        Message = message;
        ErrorStatusCode = errorStatusCode;
    }
}