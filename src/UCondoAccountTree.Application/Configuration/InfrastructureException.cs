namespace UCondoAccountTree.Application.Configuration;

public class InfrastructureException : Exception
{
    public InfrastructureException(string message, List<object> errors) : base(message)
    {
        Errors = errors;
    }

    public List<object> Errors { get; }
}
