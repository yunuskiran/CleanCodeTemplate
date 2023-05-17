using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistence;

public class Startup : Module
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("XConnection"));

            dbContextOptionsBuilder.EnableDetailedErrors();
            return new SampleDbContext(dbContextOptionsBuilder.Options);
        }).InstancePerLifetimeScope();
    }
}
