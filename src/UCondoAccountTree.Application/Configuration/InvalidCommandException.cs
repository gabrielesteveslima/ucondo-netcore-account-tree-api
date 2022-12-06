namespace UCondoAccountTree.Application.Configuration;

using FluentValidation.Results;

public class InvalidCommandException : Exception
{
    public InvalidCommandException(string message, List<ValidationFailure> errors) : base(message)
    {
        Errors = errors;
    }

    public List<ValidationFailure> Errors { get; }
}
