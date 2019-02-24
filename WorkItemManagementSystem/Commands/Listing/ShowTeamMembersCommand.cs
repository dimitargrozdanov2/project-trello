using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Listing
{
    public class ShowTeamMembersCommand:ICommand
    {
        private IDataBase dataBase;

        public ShowTeamMembersCommand(IDataBase dataBase)
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
                throw new ArgumentException("Failed to parse ShowTeamMembers command parameters.");
            }

            var teams = this.dataBase.Teams;
            var team = teams[teamName];

            var members = team.Members;
            var sb = new StringBuilder();

            sb.AppendLine($" Members in {team.TeamName}:");
            foreach (var member in members)
            {
                sb.AppendLine($" * {member.UserName}");
            }
            return sb.ToString();
        }
    }
}
