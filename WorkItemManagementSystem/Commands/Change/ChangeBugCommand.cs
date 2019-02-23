using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Commands.Changing
{
    class ChangeBugCommand : ICommand
    {
        private IDataBase database;

        public ChangeBugCommand(IDataBase dataBase)
        {
            this.database = dataBase;
        }

        public string Execute(IList<string> parameters)
        {

            string type;
            long id;
            string change;

            try
            {
                id = long.Parse(parameters[0]);
                type = parameters[1];
                change = parameters[2];

            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBug command parameters.");
            }


            var workItems = this.database.WorkItems;
            var bug = workItems[id];

            var sb = new StringBuilder();

            switch (type)
            {
                case "priority":
                    bug.ChangePriority(change.PriorityToEnum());
                    sb.AppendLine($"Priority was changed to {change}");
                    break;
                case "severity":
                    bug.ChangeSeverity(change.SeverityToEnum());
                    sb.AppendLine($"Severity was changed to {change}");

                    break;
                case "status":
                    bug.UpdateBugStatus(change.BugStatusToEnum());
                    sb.AppendLine($"Status was changed to {change}");

                    break;

                default:
                    sb.AppendLine("There is no such bug type");

                    break;
            }

            return sb.ToString();
        }
    }
}
