using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Listing
{
    public class ShowPeopleCommand:ICommand
    {
        private IDataBase dataBase;
        public ShowPeopleCommand(IDataBase dataBase)          
        {
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            var people = this.dataBase.People;

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
