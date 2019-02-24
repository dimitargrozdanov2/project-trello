using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Listing
{
    public class ShowTeamBoardsCommand:ICommand
    {
        private IDataBase dataBase;

        public ShowTeamBoardsCommand(IDataBase dataBase)
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
                throw new ArgumentException("Failed to parse ShowTeamBoard command parameters.");
            }

            var teams = this.dataBase.Teams;
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
