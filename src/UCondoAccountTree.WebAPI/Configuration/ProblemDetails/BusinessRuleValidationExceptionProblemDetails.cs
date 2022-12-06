namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails;

using Domain.SeedWorks;
using Helpers;
using Microsoft.AspNetCore.Mvc;

public class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
{
    public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
    {
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(BusinessRuleValidationExceptionProblemDetails);
        Errors = ProblemDetailsWrapErrors.GetErrors(exception);
    }

    public IEnumerable<ProblemDetailsWrapErrors> Errors { get; }
    public new string Extensions { get; set; }
}
