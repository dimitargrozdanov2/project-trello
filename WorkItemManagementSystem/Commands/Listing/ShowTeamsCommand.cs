using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowTeamsCommand : Command, ICommand
    {
        public ShowTeamsCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var teams = base.Engine.Teams;

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
