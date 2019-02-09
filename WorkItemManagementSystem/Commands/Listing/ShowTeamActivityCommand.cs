using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowTeamActivityCommand:Command
    {
        public ShowTeamActivityCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string teamName;

            try
            {
                teamName = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowTeamCommand command parameters.");
            }

            var teams = base.Engine.Teams;
            var team = teams[teamName];
            var activityHistory = team.ActivityHistory;

            var sb = new StringBuilder();
            sb.AppendLine($" Activity in {team.TeamName}:");
            foreach (var activity in activityHistory)
            {
                sb.AppendLine($" *{activity.Message} - {activity.Timestamp}");
            }
            return sb.ToString();
        }
    }
}
