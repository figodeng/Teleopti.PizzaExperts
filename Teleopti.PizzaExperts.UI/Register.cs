using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Experts.Services;
using Teleopti.PizzaExperts.Framework.Environment;
using Teleopti.PizzaExperts.Repositories.Repositories;
using Teleopti.PizzaExperts.WorkPlans.Services;

namespace Teleopti.PizzaExperts.UI
{
    /// <summary>
    /// Register
    /// </summary>
    internal partial class Program
    {
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
    }
}
