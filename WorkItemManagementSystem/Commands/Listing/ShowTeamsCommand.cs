using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowTeamsCommand :ICommand
    {
        private IDataBase dataBase;

        public ShowTeamsCommand(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            var teams = this.dataBase.Teams;

            if (teams.Count == 0)
            {
                return " There are no registered teams.";
            }

            var sb = new StringBuilder();
            sb.AppendLine(" Teams:");

            foreach (var team in teams)
            {                
                sb.AppendLine($" * {team.Key}");
            }
            return sb.ToString();
        }
    }
}
