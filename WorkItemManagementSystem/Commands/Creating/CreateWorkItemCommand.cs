using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;


namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreateWorkItemCommand : Command, ICommand
    {
        public CreateWorkItemCommand(IFactory factory, IEngine engine)
           : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string workItem;
            string title;
            string boardName;
            string teamName;

            try
            {
                workItem = parameters[0];
                title = parameters[1];
                boardName = parameters[2];
                teamName = parameters[3];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBug command parameters.");
            }


            var teams = base.Engine.Teams;
            var workItems = base.Engine.WorkItems;

            if (!teams.ContainsKey(teamName))
            {
                return $"{teamName} not exists.";
            }
            var team = teams[teamName];
            var boards = team.Boards;

            //TODO: if board name exist
            var board = team.Boards.Where(b => b.BoardName == boardName).First();

            var sb = new StringBuilder();
            workItem = workItem.ToLower();
            switch (workItem)
            {
                case "bug":
                    var bug = base.Factory.CreateBug(title);
                    board.CreateNewBug(bug);
                    long bugId = bug.Id;
                    workItems.Add(bugId, bug);
                    sb.AppendLine($"Bug was created at {board.BoardName}");
                    break;

                case "story":
                    var story = base.Factory.CreateStory(title);
                    board.CreateNewStory(story);
                    long storyId = story.Id;
                    workItems.Add(storyId, story);
                    sb.AppendLine($"Story was created at {board.BoardName}");
                    break;
                case "feedback":
                    var feedback = base.Factory.CreateFeedback(title);
                    board.CreateNewFeedback(feedback);
                    long feedbackId = feedback.Id;
                    workItems.Add(feedbackId, feedback);
                    sb.AppendLine($"Feedback was created at {board.BoardName}");
                    break;

                default:
                    return "There is no workItemType";
            }
            return sb.ToString();
        }
    }
}



