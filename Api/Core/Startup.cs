using Api.Core.Services.ServiceA;
using Api.Core.Services.ServiceA.Profiles;
using Autofac;
using AutoMapper;

namespace Api.Core;

public class Startup : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(_ => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TableAProfile>();
        }))
        .AsSelf()
        .SingleInstance();

        builder.Register(c =>
        {
            var context = c.Resolve<IComponentContext>();
            var config = context.Resolve<MapperConfiguration>();
            return config.CreateMapper(context.Resolve);
        })
        .As<IMapper>()
        .InstancePerLifetimeScope();

        builder.RegisterType<ServiceA>().As<IServiceA>().InstancePerLifetimeScope();
    }
}
