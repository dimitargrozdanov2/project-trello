using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowPeopleCommand:Command, ICommand
    {

        public ShowPeopleCommand(IFactory factory, IEngine engine)
            :base(factory,engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var people = base.Engine.People;

            if (people.Count == 0)
            {
                return " There are no registered users.";
            }

            var sb = new StringBuilder();

            sb.AppendLine(" People:");
            foreach (var person in people.Values)
            {
                sb.AppendLine($" * {person.FirstName} {person.LastName}");
            }
            return sb.ToString();
        }
    }
}
