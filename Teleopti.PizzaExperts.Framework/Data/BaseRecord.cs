using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Data
{
    /// <summary>
    /// Data Model Base Class
    /// </summary>
    public class BaseRecord
    {
        /// <summary>
        /// key
        /// </summary>
        public Guid Id { get; set; }
    }
}
