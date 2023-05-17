using Autofac;

namespace Api.Infrastructure.Middleware;

public class Startup : Module
{
    protected override void Load(ContainerBuilder builder) =>
            builder.RegisterType<ExceptionHandlerMiddleware>()
                .InstancePerLifetimeScope();
}
