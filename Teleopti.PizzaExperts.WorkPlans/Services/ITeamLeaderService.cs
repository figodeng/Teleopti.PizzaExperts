using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.WorkPlans.Models;

namespace Teleopti.PizzaExperts.WorkPlans.Services
{
    /// <summary>
    /// TeamLeader Service interface
    /// </summary>
    public interface ITeamLeaderService : IDependency
    {
        /// <summary>
        /// apply for a meeting
        /// </summary>
        /// <returns>meeting times can choose</returns>
        IEnumerable<string> ApplyforMeeting(MeetingModel model);
    }
}
