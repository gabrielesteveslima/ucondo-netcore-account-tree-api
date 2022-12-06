namespace UCondoAccountTree.WebAPI;

using Microsoft.AspNetCore;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder => { loggingBuilder.ClearProviders(); })
            .UseStartup<Startup>();
    }
}
