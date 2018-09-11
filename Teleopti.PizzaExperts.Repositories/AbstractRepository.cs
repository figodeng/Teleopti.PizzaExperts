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

namespace Teleopti.PizzaExperts.Repositories
{
    /// <summary>
    /// AbstractRepository
    /// </summary>
    public abstract class AbstractRepository<T> where T : BaseRecord
    {
        private readonly IFileService _fileService;
        private readonly IJsonConverter _jsonConverter;

        protected readonly ConcurrentDictionary<string, T> _entries;
        public AbstractRepository(IFileService fileService,
            IJsonConverter jsonConverter)
        {
            _fileService = fileService;
            _jsonConverter = jsonConverter;


            _entries = new ConcurrentDictionary<string, T>();
            Init();
        }


        /// <summary>
        /// Init
        /// </summary>
        protected abstract void Init();

        protected IEnumerable<ScheduleModel> GetAllSchedules()
        {
            var result = new List<ScheduleModel>();

            try
            {
                var jsonText = _fileService.ReadFile($"{System.Environment.CurrentDirectory}\\schedule.json");

                var scheduleDatas = _jsonConverter.Deserialize<ScheduleDatas>(jsonText);

                if (scheduleDatas.ScheduleResult != null
                    && scheduleDatas.ScheduleResult.Schedules != null)
                {
                    result = scheduleDatas.ScheduleResult.Schedules.ToList();
                }
            }
            catch (Exception ex)
            {
                //log
            }

            return result;
        }
    }
}
