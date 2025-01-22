namespace Portfolio.RepositoryPattern.Shared.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {

    }
    public ConflictException(string message, Exception exception) : base(message, exception)
    {

    }

}
