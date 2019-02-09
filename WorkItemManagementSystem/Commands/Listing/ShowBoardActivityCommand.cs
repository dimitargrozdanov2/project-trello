using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowBoardActivityCommand : Command, ICommand
    {
        public ShowBoardActivityCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string teamName;
            string boardName;

            try
            {
                teamName = parameters[1];
                boardName = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowTeamCommand command parameters.");
            }

            var teams = base.Engine.Teams;
            var team = teams[teamName];
            var board = team.Boards.Where(b => b.BoardName == boardName).First();

            var activityHistory = board.ActivityHistory;

            var sb = new StringBuilder();
            sb.AppendLine($" Activity in {board.BoardName}:");

            foreach (var activity in activityHistory)
            {
                sb.AppendLine($" #  {activity.Timestamp} - {activity.Message}");
            }
            return sb.ToString();
        }
    }
}
