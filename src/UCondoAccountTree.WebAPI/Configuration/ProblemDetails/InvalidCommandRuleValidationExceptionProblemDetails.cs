namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails;

using Application.Configuration;
using FluentValidation;
using Helpers;
using Microsoft.AspNetCore.Mvc;

public class InvalidCommandRuleValidationExceptionProblemDetails : ProblemDetails
{
    public InvalidCommandRuleValidationExceptionProblemDetails(InvalidCommandException exception)
    {
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(InvalidCommandRuleValidationExceptionProblemDetails);
        Errors = exception.Errors.Select(x => new ProblemDetailsWrapErrors { Code = x.GetHashCode(), Type = Severity.Error.ToString(), Description = x.ErrorMessage, Title = x.PropertyName });
    }

    public IEnumerable<ProblemDetailsWrapErrors> Errors { get; }
    public new string Extensions { get; set; }
}
