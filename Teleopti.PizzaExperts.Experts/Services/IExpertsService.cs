using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Experts.Models;
using Teleopti.PizzaExperts.Framework;

namespace Teleopti.PizzaExperts.Experts.Services
{
    /// <summary>
    /// Experts Services interfaces
    /// </summary>
    public interface IExpertsService: IDependency
    {
        /// <summary>
        /// allExperts in a team
        /// </summary>
        /// <param name="teamId">teamId</param>
        /// <returns></returns>
        IEnumerable<ExpertModel> GetAllExperts(string teamId = "");

        /// <summary>
        /// Create a new Expert
        /// </summary>
        void CreateExpert(ExpertModel model);

        /// <summary>
        /// Get the Expert
        /// </summary>
        /// <param name="personId">personId</param>
        /// <returns></returns>
        ExpertModel GetExpert(string personId);

        /// <summary>
        /// Remove the Expert
        /// </summary>
        /// <param name="personId">personId</param>
        /// <returns></returns>
        void RemoveExpert(string personId);
    }
}
