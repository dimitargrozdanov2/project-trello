using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Commands.Listing
{
    public class ListWorkItemsCommand :ICommand
    {
        private IDataBase dataBase;

        public ListWorkItemsCommand(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public string Execute(IList<string> parameters)
        {
            string command;

            try
            {
                command = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse ListWorkItems command parameters.");
            }

            var workItems = this.dataBase.WorkItems;

            if (workItems.Count == 0)
            {
                return " There are no registered work items.";
            }

            var sb = new StringBuilder();

            switch (command)
            {
                case "all":
                    sb.AppendLine(" Work items:");
                    foreach (var item in workItems.Values)
                    {
                        sb.AppendLine($" *{item.Тype} with id {item.Id}");
                        sb.AppendLine($" *Title:{item.Title} ");
                    }
                    break;

                case "Bug":
                    foreach (var item in workItems.Values)
                    {
                        var checker = command.ToEnum();
                        if (item.Тype == checker)
                        {
                            sb.AppendLine(" # Bugs:");
                            sb.AppendLine($"  ID: {item.Id} - title: {item.Title}");
                        }
                    }
                    break;

                case "Story":
                    foreach (var item in workItems.Values)
                    {
                        var checker = command.ToEnum();
                        if (item.Тype == checker)
                        {
                            sb.AppendLine(" # Story:");
                            sb.AppendLine($"  ID:{item.Id} - title: {item.Title}");
                        }
                    }
                    break;
                case "Feedback":
                    foreach (var item in workItems.Values)
                    {
                        var checker = command.ToEnum();
                        if (item.Тype == checker)
                        {
                            sb.AppendLine(" # Feedback:");
                            sb.AppendLine($"  ID{item.Id} - title: {item.Title}");
                        }
                    }
                    break;
            }
            return sb.ToString();
        }
    }
}
