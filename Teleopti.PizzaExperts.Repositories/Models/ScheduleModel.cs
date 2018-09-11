using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Repositories.Models
{

    /// <summary>
    /// ScheduleDatas
    /// </summary>
    public class ScheduleDatas
    {

        /// <summary>
        /// ScheduleResult
        /// </summary>
        public ScheduleResult ScheduleResult { get; set; }
    }

    /// <summary>
    /// ScheduleResult
    /// </summary>
    public class ScheduleResult
    {

        /// <summary>
        /// Schedules
        /// </summary>
        public IEnumerable<ScheduleModel> Schedules { get; set; }
    }

    /// <summary>
    /// Schedule
    /// </summary>
    public class ScheduleModel
    {
        /// <summary>
        /// ContractTimeMinutes
        /// </summary>
        public int ContractTimeMinutes { get; set; }

        /// <summary>
        /// work date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// IsFullDayAbsence
        /// </summary>
        public bool IsFullDayAbsence { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// PersonId
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Projections
        /// </summary>
        public IEnumerable<Projection> Projection { get; set; }
    }


    /// <summary>
    /// Projection
    /// </summary>
    public class Projection
    {
        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

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
    }
}
