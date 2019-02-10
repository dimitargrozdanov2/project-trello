using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreateTeamCommand : Command, ICommand
    {

        public CreateTeamCommand(IFactory factory, IEngine engine)
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
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }

            var sb = new StringBuilder();
            var teams = base.Engine.Teams;
            var members = new List<Person>();


            if (!teams.ContainsKey(teamName))
            {
                var team = base.Factory.CreateTeam(teamName);
                teams.Add(teamName, team);
                sb.Append($" Team {teamName} was created.");
            }
            else
            {
                sb.Append($" Team with name {teamName} alteady exists");
            }
           
            return sb.ToString();
        }
    }
}
