using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.Framework.Data;
using Teleopti.PizzaExperts.Framework.Services;
using Teleopti.PizzaExperts.Repositories.Models;

namespace Teleopti.PizzaExperts.Repositories.Repositories
{
    /// <summary>
    /// ExpertRepository
    /// </summary>
    public class ExpertRepository : AbstractRepository<ExpertRecord>, IExpertRepository
    {
        public ExpertRepository(IFileService fileService, IJsonConverter jsonConverter) : base(fileService, jsonConverter)
        {
        }


        public IEnumerable<ExpertRecord> Table
        {

            get
            {
                return _entries.Values;

            }

        }

        /// <summary>
        /// Init
        /// </summary>
        protected override void Init()
        {
            var schedules = GetAllSchedules();

            ExpertRecord expert = null;
            foreach (var schedule in schedules)
            {
                expert = new ExpertRecord
                {
                    PersonId = schedule.PersonId,
                    Name = schedule.Name,
                };

                AddOrUpdate(expert);
            }
        }

        private void AddOrUpdate(ExpertRecord record)
        {
            _entries.AddOrUpdate(record.PersonId,
                // "Add" lambda
                k =>
                {
                    return record;
                },
                // "Update" lambda
                (k, currentEntry) =>
                {
                    if (k == record.PersonId)
                    {
                        currentEntry.Name = record.Name;
                        currentEntry.TeamId = record.TeamId;
                    }
                    else
                    {
                        currentEntry = record;
                    }
                    return currentEntry;
                });
        }

        public void Create(ExpertRecord entity)
        {
            AddOrUpdate(entity);
        }

        public void Delete(ExpertRecord entity)
        {
            _entries.TryRemove(entity.PersonId, out entity);
        }

        public ExpertRecord Get(string id)
        {
            return Table.FirstOrDefault(m => m.Id.ToString() == id);
        }

        public void Update(ExpertRecord entity)
        {
            AddOrUpdate(entity);
        }
    }
}
