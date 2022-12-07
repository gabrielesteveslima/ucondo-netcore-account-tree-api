namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails;

using Application.Configuration;
using Domain.SeedWorks;
using Hellang.Middleware.ProblemDetails;
using Helpers;

public static class ProblemDetailsExtension
{
    internal static IServiceCollection AddProblemDetailsMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ProblemDetailsFilter>();
        services.AddProblemDetails(setup =>
        {
            setup.Map<InvalidCommandException>(exception =>
                new InvalidCommandRuleValidationExceptionProblemDetails(exception));
            setup.Map<BusinessRuleValidationException>(exception =>
                new BusinessRuleValidationExceptionProblemDetails(exception));
            setup.Map<NotFoundException>(exception =>
                new NotFoundExceptionProblemDetails(exception));
        });

        return services;
    }
}
