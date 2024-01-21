using Application.Exceptions;

namespace Application.Wrappers;

public class Response<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<ErrorModel> Errors { get; set; } = [];
    public T Data { get; set; }
    
    public Response() { }

    public Response(T data, string message = "")
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }
    
    public Response(string message, List<ErrorModel> errors)
    {
        Succeeded = false;
        Message = message;
        Errors = errors;
    }

    public static implicit operator Response<T>(Exception exception) => new(exception.Message);
    public static implicit operator Response<T>(string errorMessage) => new(errorMessage);
    public static implicit operator Response<T>(T value) => new(value);
}