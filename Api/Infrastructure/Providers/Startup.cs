using Api.Core.Providers;
using Autofac;

namespace Api.Infrastructure.Providers;

public class Startup : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SampleProvider.SampleProvider>()
            .As<ISampleProvider>()
            .InstancePerLifetimeScope();
    }
}
