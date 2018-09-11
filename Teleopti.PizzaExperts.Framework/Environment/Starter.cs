using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.Framework.Environment;

namespace Teleopti.PizzaExperts
{
    /// <summary>
    /// application Starter
    /// </summary>
    public class Starter
    {
        /// <summary>
        /// Create Host
        /// </summary>
        /// <param name="registrations"></param>
        /// <returns></returns>
        public static IPizzaExpertsHost CreateHost(Action<ContainerBuilder> registrations)
        {
            var container = CreateHostContainer(registrations);
            return container.Resolve<IPizzaExpertsHost>();
        }

        /// <summary>
        /// Build Autofac Container
        /// </summary>
        /// <returns></returns>
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();

            registrations(builder);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyModules(assemblies.ToArray());

            var dependencyTypes = assemblies.SelectMany(c => c.ExportedTypes)
                .Where(t => !t.IsAbstract && !t.IsInterface&& typeof(IDependency).IsAssignableFrom(t));

            foreach (var item in dependencyTypes)
            {
                var registration = builder.RegisterType(item)
                    //.EnableDynamicProxy(dynamicProxyContext)
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

            var container = builder.Build();
            
            return container;
        }

        /// <summary>
        /// Get Root Namespaces
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetRootNamespaces(Type type)
        {
            var segments = type.Namespace.Split(Type.Delimiter);

            return segments.FirstOrDefault();
        }
    }
}
