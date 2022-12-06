namespace UCondoAccountTree.Application.Configuration;

using FluentValidation;
using FluentValidation.Results;
using MediatR;

public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IList<IValidator<TRequest>> _validators;

    public CommandValidationBehavior(IList<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        List<ValidationFailure> errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        return errors.Any() ? throw new InvalidCommandException(string.Empty, errors) : next();
    }
}
