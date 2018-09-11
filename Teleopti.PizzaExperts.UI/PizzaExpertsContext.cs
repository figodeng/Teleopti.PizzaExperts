using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.UI.Commands;

namespace Teleopti.PizzaExperts.UI
{
    /// <summary>
    /// PizzaExpertsContext
    /// </summary>
    internal class PizzaExpertsContext
    {
        /// <summary>
        /// Current Command
        /// </summary>
        public UI.Commands.AbstractCommand CurrentCommand { get; set; }
    }
}
