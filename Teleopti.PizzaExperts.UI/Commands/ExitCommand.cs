using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.UI.Commands
{
    /// <summary>
    /// ExitCommand
    /// </summary>
    internal class ExitCommand : AbstractCommand
    {
        /// <summary>
        /// Construction method
        /// </summary>
        public ExitCommand() : base(Constants.Exit, string.Empty)
        {
        }
    }
}
