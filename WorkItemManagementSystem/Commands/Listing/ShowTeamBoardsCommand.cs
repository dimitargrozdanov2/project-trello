using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowTeamBoardsCommand:Command,ICommand
    {
        public ShowTeamBoardsCommand(IFactory factory, IEngine engine)
            :base(factory,engine)
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
                throw new ArgumentException("Failed to parse ShowTeamBoards command parameters.");
            }

            var teams = base.Engine.Teams;
            var team = teams[teamName];
            var boards = team.Boards;
          
            var sb = new StringBuilder();
            sb.AppendLine($" Boards in {team.TeamName}:");
            foreach (var board in boards)
            {
                sb.AppendLine($" * {board.BoardName}");
            }
            return sb.ToString();
        }
    }
}
