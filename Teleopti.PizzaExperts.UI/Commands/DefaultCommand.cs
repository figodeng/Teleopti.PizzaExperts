using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.UI.ViewModels;

namespace Teleopti.PizzaExperts.UI.Commands
{
    /// <summary>
    /// DefaultCommand
    /// </summary>
    internal class DefaultCommand : AbstractCommand
    {
        /// <summary>
        /// Construction method
        /// </summary>
        /// <param name="input">input infos</param>
        public DefaultCommand(string input):base(input, string.Empty)
        {
            int number = 0;
            if (int.TryParse(input, out number))
            {
                Parameters = new InputViewModel
                {
                    Number = number
                };
            }
        }

        /// <summary>
        /// command Paramters
        /// </summary>
        public InputViewModel Parameters { get; set; }
    }
}
