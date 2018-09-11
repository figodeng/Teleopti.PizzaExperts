using Autofac;
using Autofac.Core;
using Autofac.Features.Indexed;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using VICloud.ApiGateway.Data;
using VICloud.ApiGateway.Environment.AutofacUtil.DynamicProxy2;
using VICloud.ApiGateway.Logging;
using VICloud.ApiGateway.WebApi;
using VICloud.ApiGateway.WebApi.Filters;
using VICloud.ApiGateway.WebApi.Handlers;

namespace VICloud.ApiGateway.Environment
{
    public static class VICloudStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();
            var dynamicProxyContext = new DynamicProxyContext();

            builder.RegisterModule(new CollectionOrderModule());
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new DataModule());

            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.Register(ctx => dynamicProxyContext);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(c => c.FullName.StartsWith(GetRootNamespaces(typeof(VICloudStarter))));
            builder.RegisterAssemblyModules(assemblies.ToArray());

            var dependencyTypes = assemblies.SelectMany(c => c.ExportedTypes)
                .Where(t => typeof(IDependency).IsAssignableFrom(t));
            foreach (var item in dependencyTypes.Where(c => !c.IsAbstract && !c.IsInterface))
            {
                var registration = builder.RegisterType(item)
                    .EnableDynamicProxy(dynamicProxyContext)
                    .InstancePerLifetimeScope();

                foreach (var interfaceType in item.GetInterfaces()
                    .Where(itf => typeof(IDependency).IsAssignableFrom(itf)))
                {
                    registration = registration.As(interfaceType).AsSelf();
                    if (typeof(ISingletonDependency).IsAssignableFrom(interfaceType))
                    {
                        registration = registration.SingleInstance();
                    }
                    else if (typeof(ITransientDependency).IsAssignableFrom(interfaceType))
                    {
                        registration = registration.InstancePerDependency();
                    }
                }
            }

            registrations(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.Filters.Add(new VICloudApiActionFilterDispatcher());
            GlobalConfiguration.Configuration.MessageHandlers.Add(new EncryptDecodeMessageHandler(container));
            GlobalConfiguration.Configuration.Filters.Add(new VICloudApiAuthorizationFilterDispatcher(container));
            GlobalConfiguration.Configuration.Filters.Add(new VICloudApiExceptionFilterDispatcher());
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        public static string GetRootNamespaces(Type type)
        {
            var segments = type.Namespace.Split(Type.Delimiter);

            return segments.FirstOrDefault();
        }
    }
}