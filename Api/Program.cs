using Api.Configurations;
using Api.Infrastructure.Shared;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Serilog;
using Api.Shared.Filters;

StaticLogger.EnsureInitialized();
Log.Information("Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.AddConfigurations(builder.Environment.EnvironmentName);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(containerBuilder =>
       {
           containerBuilder.RegisterModule(new Api.Infrastructure.Startup(builder.Configuration));
           containerBuilder.RegisterModule(new Api.Core.Startup());
       });

    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console().ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services.AddControllers(options => { options.Filters.Add<ValidateRequestFilter>(); });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Shutting down...");
    Log.CloseAndFlush();
}