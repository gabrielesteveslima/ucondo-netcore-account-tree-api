namespace UCondoAccountTree.WebAPI.Configuration.Docs;

using Microsoft.AspNetCore.Mvc;

public static class VersioningExtension
{
    internal static IServiceCollection AddVersioningSystem(this IServiceCollection services)
    {
        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.ReportApiVersions = true;
            setup.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
