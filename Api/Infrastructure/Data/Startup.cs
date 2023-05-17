using Api.Domain.SchemaFirst;
using Api.Infrastructure.Data.SchemaFirst;
using Api.Infrastructure.Data.SchemaSecond;
using Autofac;

namespace Api.Infrastructure.Data;

public class Startup : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(SchemaFirstRepository<>))
         .As(typeof(ISchemaFirstRepository<>))
         .InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(SchemaSecondRepository<>))
        .As(typeof(ISchemaFirstRepository<>))
        .InstancePerLifetimeScope();
    }
}
