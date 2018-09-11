using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teleopti.PizzaExperts.Experts.Services;
using Teleopti.PizzaExperts.Framework.Environment;
using Teleopti.PizzaExperts.Repositories.Repositories;
using Teleopti.PizzaExperts.UI;
using Teleopti.PizzaExperts.WorkPlans.Services;

namespace Teleopti.PizzaExperts.Tests
{
    [TestClass]
    public abstract class AbstractUnitTest : System.IDisposable
    {
        protected static ILifetimeScope _scope;

        public AbstractUnitTest()
        {
            var container = Starter.CreateHostContainer(RegisterServices);


            _scope = container.BeginLifetimeScope();
        }

        static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaExpertsClient>().As<IPizzaExpertsHost>().SingleInstance();

            //AppDomain.CurrentDomain can not get all Assemblies.just regist those services as follows
            builder.RegisterType<ExpertsService>().As<IExpertsService>().InstancePerLifetimeScope();
            builder.RegisterType<TeamLeaderService>().As<ITeamLeaderService>().InstancePerLifetimeScope();
            builder.RegisterType<MeetingService>().As<IMeetingService>().InstancePerLifetimeScope();

            builder.RegisterType<ExpertRepository>().As<IExpertRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExpertDutyRepository>().As<IExpertDutyRepository>().InstancePerLifetimeScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
