using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.Framework.Utility.Validation;
using Teleopti.PizzaExperts.WorkPlans.Models;

namespace Teleopti.PizzaExperts.WorkPlans.Services
{
    /// <summary>
    /// TeamLeader Services
    /// </summary>
    public class TeamLeaderService : ITeamLeaderService
    {
        private readonly IMeetingService _meetingService;

        public TeamLeaderService(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        /// <summary>
        /// apply for a meeting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<string> ApplyforMeeting(MeetingModel model)
        {
            Argument.ThrowIfNull(model, nameof(model));
            Argument.Validate(model.Participants > 0, nameof(model.Participants), "Number of participants must be above 0");

            if (!_meetingService.CanMeeting(model.Participants))
            {
                throw new PizzaExpertsException("there is not enough people at work");
            }

            return _meetingService.MeetingTimes(model.Participants);
        }
    }
}
