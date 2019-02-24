using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Listing
{
    public class ShowTeamActivityCommand:ICommand
    {
        private IDataBase dataBase;

        public ShowTeamActivityCommand(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            string teamName;

            try
            {
                teamName = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowTeamActivity command parameters.");
            }

            var teams = this.dataBase.Teams;
            var team = teams[teamName];
            var activityHistory = team.ActivityHistory;

            var sb = new StringBuilder();
            sb.AppendLine($" Activity in {team.TeamName}:");
            foreach (var activity in activityHistory)
            {
                sb.AppendLine($" #  {activity.Timestamp} - {activity.Message}");
            }
            return sb.ToString();
        }
    }
}
