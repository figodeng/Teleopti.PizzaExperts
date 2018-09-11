using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleopti.PizzaExperts.Experts.Services;
using Teleopti.PizzaExperts.Framework;
using Teleopti.PizzaExperts.Repositories.Models;
using Teleopti.PizzaExperts.Repositories.Repositories;

namespace Teleopti.PizzaExperts.WorkPlans.Services
{
    /// <summary>
    /// Meeting Services
    /// </summary>
    public class MeetingService : IMeetingService
    {
        private readonly IExpertsService _expertsService;
        private readonly IExpertDutyRepository _expertDutyRepository;
        private const int _meetingIntervalMinutes = 15;
        public MeetingService(IExpertsService expertsService, IExpertDutyRepository expertDutyRepository)
        {
            _expertsService = expertsService;
            _expertDutyRepository = expertDutyRepository;
        }

        /// <summary>
        /// Can Meeting
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CanMeeting(int num)
        {
            if (num <= 0)
            {
                throw new PizzaExpertsException("Number of participants must be above 0");
            }

            var allExperts = _expertsService.GetAllExperts();

            return allExperts.Count() >= num;
        }

        /// <summary>
        /// Number of participants
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<string> MeetingTimes(int num)
        {
            if (num <= 0)
            {
                throw new PizzaExpertsException("Number of participants must be above 0");
            }
            var result = new List<string>();

            var expertDutyRecords = GetExpertDutyRecords();
            if (expertDutyRecords.Count() >= num)
            {
                var startWorkTime = expertDutyRecords.FirstOrDefault().Start;

                var endWorkTime = expertDutyRecords.OrderByDescending(m => m.End).FirstOrDefault().End;

                DateTime meetingEndTime;
                int count = 0;
                for (var start = startWorkTime; start <= endWorkTime; start = start.AddMinutes(_meetingIntervalMinutes))
                {
                    meetingEndTime = startWorkTime.AddMinutes(_meetingIntervalMinutes);
                    count = expertDutyRecords.Count(m => m.Start <= start && m.End >= meetingEndTime);
                    if (count >= num)
                    {
                        result.Add(Convert.ToString(start));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// get all records that experts is at work
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ExpertDutyRecord> GetExpertDutyRecords()
        {
            return _expertDutyRepository.Table.OrderBy(m=>m.Start);
        }
    }
}
