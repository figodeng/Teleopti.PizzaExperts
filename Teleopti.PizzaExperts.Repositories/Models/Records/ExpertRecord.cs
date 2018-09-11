using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework.Data;

namespace Teleopti.PizzaExperts.Repositories.Models
{
    /// <summary>
    /// Expert Data Model
    /// </summary>
    public class ExpertRecord : BaseRecord
    {
        /// <summary>
        /// TeamId
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// PersonId
        /// </summary>
        public string PersonId { get; set; }
    }
}
