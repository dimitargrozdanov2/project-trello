﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Commands.Changing
{
    class ChangeStoryCommand : ICommand
    {
        private IDataBase database;

        public ChangeStoryCommand(IDataBase dataBase)
        {
            this.database = dataBase;
        }

        public  string Execute(IList<string> parameters)
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
                throw new ArgumentException("Failed to parse ChangeStory command parameters.");
            }


            var workItems = this.database.WorkItems;
            var story = workItems[id];

            var sb = new StringBuilder();

            switch (type)
            {
                case "priority":
                    story.ChangePriority(change.PriorityToEnum());
                    sb.AppendLine($"Priority was changed to {change}");
                    break;
                case "severity":
                    story.ChangeSize(change.StorySizeTypeToEnum());
                    sb.AppendLine($"Size was changed to {change}");

                    break;
                case "status":
                    story.UpdateStoryStatus(change.StoryStatusToEnum());
                    sb.AppendLine($"Status was changed to {change}");

                    break;

                default:
                    sb.AppendLine("There is no such story type");

                    break;
            }

            return sb.ToString();
        }
    }
}
