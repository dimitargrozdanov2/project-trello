using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Commands.Change
{
    class ChangeStoryPriority : Command
    {
        public ChangeStoryPriority(IFactory factory, IEngine engine)
          : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            Story story;
            string newPrio;

            try
            {
                story = parameters[0];
                newPrio = parameters[1]; 
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangePriorityonStory command parameters.");
            }
            var sb = new StringBuilder();
            sb.AppendLine($" {newPrio} priority:");
            var priority = .Story;
            var activityHistory = 

            foreach (var activity in activityHistory)
            {
                sb.Append($" #  {activity.Timestamp} - {activity.Message}" + "\r\n");
            }
            return sb.ToString();
        }
    }
}
