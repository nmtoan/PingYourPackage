using Autofac;
using Autofac.Integration.WebApi;
using PingYourPackage.Domain.Entities;
using PingYourPackage.Domain.Services;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace PingYourPackage.API.Config
{
    // IoC container configuration
    public class AutofacWebAPI
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // registration goes here

            // EF DbContext
            builder.RegisterType<EntitiesContext>().As<DbContext>().InstancePerApiRequest();

            // Register repositories by using Autofac's OpenGenerics feature
            // More info: https://code.google.com/archive/p/autofac/wikis/OpenGenerics.wiki
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IEntityRepository<>)).InstancePerApiRequest();

            // Services
            builder.RegisterType<CryptoService>().As<ICryptoService>().InstancePerApiRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerApiRequest();
            // register ShipmentService

            return builder.Build();
        }
    }
}
