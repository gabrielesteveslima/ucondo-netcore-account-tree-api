namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails.Helpers;

using Application.Configuration;
using Infrastructure.Logs;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

public class ProblemDetailsFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        switch (exception)
        {
            case NotFoundException notFoundException:
                Log.Warning(notFoundException);
                break;
            case InvalidCommandException commandException:
                Log.Error(commandException.Errors);
                break;
            case JsonException jsonException:
                Log.Error(jsonException);
                break;
            default:
                Log.Error(exception);
                break;
        }
    }
}
