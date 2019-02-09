using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowPersonActivityCommand : Command, ICommand
    {
        public ShowPersonActivityCommand(IFactory factory, IEngine engine)
         : base(factory, engine)
        {
        }
        public override string Execute(IList<string> parameters)
        {

            string personName;

            try
            {
                personName = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowPersonActivity command parameters.");
            }
            var people = base.Engine.People;

            if (people.Count == 0)
            {
                return " No people were created yet.";
            }

            var sb = new StringBuilder();

            var person = people[personName] != null ? people[personName] : throw new ArgumentException("No such person exists");
            sb.AppendLine($" {personName} activity:");

            var AH = String.Join("\n\r * ", person.ShowActivityHistory());
            sb.AppendLine($" * {AH} ");
            
            return sb.ToString();
        }
    }
}
