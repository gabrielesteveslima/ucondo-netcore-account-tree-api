namespace UCondoAccountTree.Infrastructure;

using Database;
using Domain;
using InProc;
using Logs;

public class ApplicationStartup
{
    public static IServiceProvider Initialize(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var serviceProvider = CreateAutofacServiceProvider(services, configuration);
        return serviceProvider;
    }

    private static IServiceProvider CreateAutofacServiceProvider(
        IServiceCollection services,
        IConfiguration configuration)
    {
        ContainerBuilder container = new();

        container.Populate(services);

        container.RegisterModule(new DatabaseModule(configuration.GetConnectionString("Default")));
        container.RegisterModule(new InProcModule(configuration));
        container.RegisterModule(new DomainModule(configuration));
        container.RegisterModule(new LogModule());

        var buildContainer = container.Build();

        ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));
        AutofacServiceProvider serviceProvider = new(buildContainer);
        return serviceProvider;
    }
}
