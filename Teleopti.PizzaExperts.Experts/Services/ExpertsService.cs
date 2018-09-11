using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Experts.Models;
using Teleopti.PizzaExperts.Framework.Utility.Extensions;
using Teleopti.PizzaExperts.Framework.Utility.Validation;
using Teleopti.PizzaExperts.Repositories.Models;
using Teleopti.PizzaExperts.Repositories.Repositories;

namespace Teleopti.PizzaExperts.Experts.Services
{
    /// <summary>
    /// Experts Services
    /// </summary>
    public class ExpertsService : IExpertsService
    {
        private readonly IExpertRepository _repository;

        /// <summary>
        ///  Construction method
        /// </summary>
        /// <param name="repository"></param>
        public ExpertsService(IExpertRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create a new Expert
        /// </summary>
        /// <param name="model"></param>
        public void CreateExpert(ExpertModel model)
        {
            Argument.ThrowIfNull(model, nameof(model));

            var record = new ExpertRecord {
                PersonId=model.PersonId,
                Name=model.Name,
            };

            _repository.Create(record);
        }

        public IEnumerable<ExpertModel> GetAllExperts(string teamId = "")
        {
            Func<ExpertRecord, bool> predicate = m => true;

            if (!teamId.IsEmpty())
            {
                predicate = m => m.TeamId == teamId;
            }

            return _repository.Table.Where(predicate)
                .Select(m=>new ExpertModel(m))
                .ToList();

        }

        /// <summary>
        ///  Get the Expert
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public ExpertModel GetExpert(string personId)
        {
            ExpertModel model = null;

            var record = _repository.Table.FirstOrDefault(m => m.PersonId == personId);

            if (record != null)
            {
                model = new ExpertModel(record);
            }

            return model;
        }

        /// <summary>
        /// Remove the Expert
        /// </summary>
        /// <param name="personId"></param>
        public void RemoveExpert(string personId)
        {
            var record = _repository.Table.FirstOrDefault(m => m.PersonId == personId);

            if (record != null)
            {
                _repository.Delete(record);
            }
        }
    }
}
