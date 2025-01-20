namespace Portfolio.RepositoryPattern.Exceptions;

public class RepositoryConflictException : Exception
{
    public RepositoryConflictException(string message) : base(message)
    {

    }
    public RepositoryConflictException(string message, Exception exception) : base(message, exception)
    {

    }
}
