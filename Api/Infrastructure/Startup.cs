using Autofac;

namespace Api.Infrastructure;

public class Startup : Module
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new Data.Startup());
        builder.RegisterModule(new Persistence.Startup(_configuration));
        builder.RegisterModule(new Providers.Startup());
        builder.RegisterModule(new Shared.Startup(_configuration));
    }
}
