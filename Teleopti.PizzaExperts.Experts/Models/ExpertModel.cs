using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Repositories.Models;

namespace Teleopti.PizzaExperts.Experts.Models
{
    /// <summary>
    /// Expert Business Model
    /// </summary>
    public class ExpertModel
    {
        /// <summary>
        ///  Construction method
        /// </summary>
        /// <param name="record"></param>
        public ExpertModel(ExpertRecord record)
        {
            TeamId = record.TeamId;
            Name = record.Name;
            PersonId = record.PersonId;
        }
        
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
