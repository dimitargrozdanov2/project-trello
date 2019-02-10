using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Listing
{
    class ShowPersonActivityCommand : Command
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
            var activityHistory = person.ActivityHistory;
            foreach (var activity in activityHistory)
            {
                sb.AppendLine($" #  {activity.Timestamp} - {activity.Message}");
            }
            return sb.ToString();
        }
    }
}
