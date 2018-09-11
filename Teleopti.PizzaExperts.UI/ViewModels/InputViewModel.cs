using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.WorkPlans.Models;

namespace Teleopti.PizzaExperts.UI.ViewModels
{
    /// <summary>
    /// InputViewModel
    /// </summary>
    internal class InputViewModel
    {
        /// <summary>
        /// Number of participants
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Convert InputViewModel To MeetingModel
        /// </summary>
        /// <param name="model">InputViewModel</param>
        /// <returns>MeetingModel</returns>
        internal static MeetingModel ConvertToMeetingModel(InputViewModel model)
        {
            MeetingModel result = null;

            if (model != null)
            {
                result = new MeetingModel
                {
                    Participants = model.Number,
                };
            }

            return result;
        }
    }
}
