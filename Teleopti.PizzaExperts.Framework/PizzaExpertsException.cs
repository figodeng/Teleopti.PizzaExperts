using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework
{
    /// <summary>
    /// PizzaExpertsException
    /// </summary>
    public class PizzaExpertsException : ApplicationException
    {
        /// <summary>
        ///  Construction method
        /// </summary>
        /// <param name="message"></param>
        public PizzaExpertsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Construction method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public PizzaExpertsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
