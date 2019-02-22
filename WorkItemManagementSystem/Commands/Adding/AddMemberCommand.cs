using System;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Adding
{
    public class AddMemberCommand : ICommand
    {
        private IDataBase database;

        public AddMemberCommand(IDataBase DataBase)
        {
            this.database = DataBase;
        }

        public string Execute(IList<string> parameters)
        {

            string userName;
            string teamName;

            try
            {
                userName = parameters[0];
                teamName = parameters[2];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddMember command parameters.");
            }

            
            var teams = this.database.Teams;
            var people = this.database.People;
            
            if (!teams.ContainsKey(teamName))
            {
                return $"{teamName} not exist";
            }
            if (!people.ContainsKey(userName))
            {
                return $"{userName} not exist";
            }

            var team = teams[teamName];
            var member = people[userName];

            team.AddMember(member);

            string result = $" {member.FirstName} {member.LastName} was added to {teamName}";

            return result;
        }
    }
}
