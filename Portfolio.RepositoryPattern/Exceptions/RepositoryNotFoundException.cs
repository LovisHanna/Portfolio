namespace Portfolio.RepositoryPattern.Exceptions;

public class RepositoryNotFoundException : Exception
{
    public RepositoryNotFoundException(string message) : base(message)
    {

    }
    public RepositoryNotFoundException(string message, Exception exception) : base(message, exception)
    {

    }
}
