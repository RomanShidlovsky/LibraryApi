using Application.Exceptions;

namespace Application.Wrappers;

public class Response<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<ErrorModel> Errors { get; set; }
    public T Data { get; set; }
    
    public Response() { }

    public Response(T data, string message = "")
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(string message, List<ErrorModel> errors)
    {
        Succeeded = false;
        Message = message;
        Errors = errors;
    }
}