using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Environment
{
    /// <summary>
    /// PizzaExperts Host
    /// </summary>
    public interface IPizzaExpertsHost: System.IDisposable
    {
        /// <summary>
        /// ShowTips
        /// </summary>
        /// <param name="tips"></param>
        void ShowTips(string tips);

        /// <summary>
        /// InputCommand
        /// </summary>
        void InputCommand();

        /// <summary>
        ///  Calculate meeting time
        /// </summary>
        void CalcMeetingTimes();

        /// <summary>
        /// Exit
        /// </summary>
        /// <returns>Is user want to Exit</returns>
        bool IsExit();
    }
}
