namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails;

using Application.Configuration;
using Microsoft.AspNetCore.Mvc;

public class NotFoundExceptionProblemDetails : ProblemDetails
{
    public NotFoundExceptionProblemDetails(NotFoundException exception)
    {
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(NotFoundExceptionProblemDetails);
        Detail = exception.Details;
    }
    
    public new string Extensions { get; set; }
}
