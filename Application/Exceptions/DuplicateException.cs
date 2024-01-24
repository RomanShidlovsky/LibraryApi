namespace Application.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException() : base("Entity is already exists")
    { }

    public DuplicateException(string message) : base(message)
    { }
}
