using System;
using System.Linq;
using Teleopti.PizzaExperts.Framework.Environment;
using Teleopti.PizzaExperts.UI.Commands;
using Teleopti.PizzaExperts.UI.ViewModels;
using Teleopti.PizzaExperts.WorkPlans.Services;

namespace Teleopti.PizzaExperts.UI
{
    /// <summary>
    /// cosole proxy
    /// </summary>
    public class PizzaExpertsClient : IPizzaExpertsHost
    {
        private static PizzaExpertsContext Context;
        private readonly ITeamLeaderService _teamLeaderService;
        public PizzaExpertsClient(ITeamLeaderService teamLeaderService)
        {
            _teamLeaderService = teamLeaderService;

            Console.Title = Constants.PizzaExperts;

            Context = new PizzaExpertsContext();

            ShowTips($"{ConstantTips.InputTip}{ConstantTips.ExitTip}");
        }

        /// <summary>
        /// ShowTips
        /// </summary>
        public void ShowTips(string tips)
        {
            Console.WriteLine(tips);
        }

        /// <summary>
        /// InputCommand
        /// </summary>
        public void InputCommand()
        {
            var command = Console.ReadLine();

            if (Constants.Exit.Equals(command, StringComparison.CurrentCultureIgnoreCase))
            {
                Context.CurrentCommand = new ExitCommand();
            }
            else
            {
                Context.CurrentCommand = new DefaultCommand(command);
            }
        }

        /// <summary>
        /// Calculate meeting time
        /// </summary>
        public void CalcMeetingTimes()
        {
            if (Context.CurrentCommand is DefaultCommand)
            {
                var command = (DefaultCommand)Context.CurrentCommand;
                if (command != null && command.Parameters != null)
                {
                    var meetingTimes = _teamLeaderService.ApplyforMeeting(InputViewModel.ConvertToMeetingModel(command.Parameters));

                    if (meetingTimes.Count() > 0)
                    {
                        ShowTips(string.Format("If you are looking for {2} Person having a meeting.{0}{1}", ConstantTips.CompleteTip,
                            string.Join(",", meetingTimes),
                            command.Parameters.Number));
                    }
                    else
                    {
                        ShowTips(ConstantTips.NotenoughTip);
                    }
                }
                else
                {
                    ShowTips(ConstantTips.InputErrTip);
                }

                ShowTips($"{ConstantTips.InputTip}{ConstantTips.ExitTip}");
            }
            else
            {
                ShowTips(ConstantTips.InputErrTip);
            }
        }


        /// <summary>
        /// exit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsExit()
        {
            return Context.CurrentCommand is ExitCommand;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Context = null;
        }
    }
}
