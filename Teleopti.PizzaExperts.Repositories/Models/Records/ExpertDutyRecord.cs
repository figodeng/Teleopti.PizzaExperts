using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework.Data;

namespace Teleopti.PizzaExperts.Repositories.Models
{
    /// <summary>
    /// Datas aboat Expert At Work
    /// </summary>
    public class ExpertDutyRecord : BaseRecord
    {
        /// <summary>
        /// PersonId
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// duration
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// endTime
        /// </summary>
        public DateTime End { get { return Start.AddMinutes(Minutes); } }

    }
}
