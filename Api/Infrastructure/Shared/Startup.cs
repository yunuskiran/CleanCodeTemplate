using Api.Infrastructure.Shared.Data;
using Api.Shared.Data;
using Autofac;

namespace Api.Infrastructure.Shared;

public class Startup : Module
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SampleSerializer>()
         .As<ISerializer>()
         .InstancePerLifetimeScope();

        builder.RegisterType<SqlConnectionFactory>()
           .As<ISqlConnectionFactory>()
           .WithParameter("connectionString", _configuration.GetConnectionString("XConnection"))
           .InstancePerLifetimeScope();
    }
}
