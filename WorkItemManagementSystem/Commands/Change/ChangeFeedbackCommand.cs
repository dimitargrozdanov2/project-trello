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
    class ChangeFeedbackCommand : ICommand
    {
        private IDataBase database;

        public ChangeFeedbackCommand(IDataBase dataBase)
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
                throw new ArgumentException("Failed to parse ChangeFeedback command parameters.");
            }


            var workItems = this.database.WorkItems;
            var feedback = workItems[id];

            var sb = new StringBuilder();

            switch (type)
            {
                case "rating":
                    int newRating = int.Parse(change);
                    feedback.ChangeRating(newRating);
                    sb.AppendLine($"Rating was changed to {change}");
                    break;
                case "status":
                    feedback.UpdateFeedbackStatus(change.FeedbackStatusToEnum());
                    sb.AppendLine($"Status was changed to {change}");

                    break;

                default:
                    sb.AppendLine("There is no such feedback type");

                    break;
            }

            return sb.ToString();
        }
    }
}

