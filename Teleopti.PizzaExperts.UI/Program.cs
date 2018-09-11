using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Experts.Services;
using Teleopti.PizzaExperts.Framework.Environment;

namespace Teleopti.PizzaExperts.UI
{
    /// <summary>
    /// Console Application
    /// </summary>
    internal partial class Program
    {
        /// <summary>
        /// entrance
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            using (var client = Starter.CreateHost(RegisterServices))
            {
                do
                {
                    try
                    {
                        client.InputCommand();
                        client.CalcMeetingTimes();
                    }
                    catch (Exception ex)
                    {
                        client.ShowTips(ex.Message);
                    }

                } while (!client.IsExit());
            }
        }

    }
}
