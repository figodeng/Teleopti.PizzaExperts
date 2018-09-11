using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework;

namespace Teleopti.PizzaExperts.WorkPlans.Services
{
    /// <summary>
    /// Meeting interface
    /// </summary>
    public interface IMeetingService: IDependency
    {
        /// <summary>
        /// Can Meeting
        /// </summary>
        /// <param name="num">Number of participants</param>
        /// <returns></returns>
        bool CanMeeting(int num);

        /// <summary>
        /// Number of participants
        /// </summary>
        /// <param name="num">Number of participants</param>
        /// <returns></returns>
        IEnumerable<string> MeetingTimes(int num);
    }
}
