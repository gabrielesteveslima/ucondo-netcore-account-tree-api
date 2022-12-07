namespace UCondoAccountTree.WebAPI.Configuration.Docs;

using Microsoft.OpenApi.Models;

internal static class SwaggerExtension
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo { Title = "UCondo Account Tree API V1", Version = "v1" });
        });

        return services;
    }

    internal static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(setup =>
        {
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "UCondo Account Tree API V1");
        });
    }
}
