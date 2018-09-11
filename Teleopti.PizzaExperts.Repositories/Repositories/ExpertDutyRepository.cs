using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.Framework.Services;
using Teleopti.PizzaExperts.Repositories.Models;

namespace Teleopti.PizzaExperts.Repositories.Repositories
{
    /// <summary>
    /// ExpertDuty Repository
    /// </summary>
    public class ExpertDutyRepository : AbstractRepository<ExpertDutyRecord>, IExpertDutyRepository
    {
        public ExpertDutyRepository(IFileService fileService, IJsonConverter jsonConverter) : base(fileService, jsonConverter)
        {
        }

        public IEnumerable<ExpertDutyRecord> Table
        {

            get
            {
                return _entries.Values;
            }
        }

        public void Create(ExpertDutyRecord entity)
        {
            AddOrUpdate(entity);
        }

        public void Delete(ExpertDutyRecord entity)
        {
            _entries.TryRemove(Convert.ToString(entity.Id), out entity);
        }

        public ExpertDutyRecord Get(string id)
        {
            return Table.FirstOrDefault(m => m.Id.ToString() == id);
        }

        public void Update(ExpertDutyRecord entity)
        {
            throw new NotImplementedException();
        }

        protected override void Init()
        {
            var schedules = GetAllSchedules();

            ExpertDutyRecord record = null;
            foreach (var schedule in schedules)
            {
                foreach (var projection in schedule.Projection)
                {
                    //exclude Short break and Lunch
                    if (projection.Description.Equals("Short break")
                        || projection.Description.Equals("Lunch")) continue;

                    record = new ExpertDutyRecord
                    {
                        Id = Guid.NewGuid(),
                        PersonId = schedule.PersonId,
                        Start = projection.Start,
                        Minutes = projection.Minutes,
                        Description = projection.Description,
                    };

                    AddOrUpdate(record);
                }

            }
        }

        private void AddOrUpdate(ExpertDutyRecord record)
        {
            _entries.AddOrUpdate(record.Id.ToString(),
                // "Add" lambda
                k =>
                {
                    return record;
                },
                // "Update" lambda
                (k, currentEntry) =>
                {
                    if (k == Convert.ToString(record.Id))
                    {
                        currentEntry.Start = record.Start;
                        currentEntry.PersonId = record.PersonId;
                        currentEntry.Minutes = record.Minutes;
                        currentEntry.Description = record.Description;
                    }
                    else
                    {
                        currentEntry = record;
                    }
                    return currentEntry;
                });
        }
    }
}
