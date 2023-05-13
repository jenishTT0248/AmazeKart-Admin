using AmazeKart.User.OrderService;
using log4net;
using Microsoft.Extensions.Hosting;

Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
                   .AddEnvironmentVariables()
.Build();

//Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

try
{
    //IHost host = Host.CreateDefaultBuilder(args)
    //.UseContentRoot(Directory.GetCurrentDirectory())
    //.UseWindowsService()
    //.ConfigureAppConfiguration((context, config) =>
    //{
    //    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    //    config.AddEnvironmentVariables();
    //})
    //.ConfigureServices((hostContext, services) =>
    //{
    //    //services.Configure<AppSettings>(hostContext.Configuration);
    //    //services.AddHttpClient();
    //    services.AddMemoryCache();
    //    services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

    //    services.AddOtherServices(hostContext, builder.Configuration);
    //})
    //.UseSerilog((context, config) =>
    //{
    //    config.ReadFrom.Configuration(context.Configuration);
    //})
    //.Build();

    //await host.RunAsync();
}
catch (Exception e)
{
    //Log.Fatal(e, "Pricing service terminated unexpectedly");
}
finally
{
    //Log.CloseAndFlush();
}
