using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models
{
    public class Board
    {
        private string boardName;
        private List<WorkItem> workItems = new List<WorkItem>();
        private List<LogItem> activityHistory = new List<LogItem>();


        public Board(string boardName)
        {
            this.BoardName = boardName;
            this.ActivityHistory.Add(new LogItem($"{boardName} created"));
        }

        //TODO: write comment
        public string BoardName
        {
            get
            {
                return this.boardName;
            }
            set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.boardName = value;
            }
        }

        public List<WorkItem> WorkItems
        {
            get
            {
                return new List<WorkItem>(workItems);
            }
        }

        public List<LogItem> ActivityHistory
        {
            get
            {
                return new List<LogItem>(this.activityHistory);
            }
        }

        public void CreateNewBug(Bug bug)
        {
            this.WorkItems.Add(bug);
            this.activityHistory.Add(new LogItem($"Bug {bug.Title} created"));
        }

        public void CreateNewStory(Story story)
        {
            this.WorkItems.Add(story);
            this.activityHistory.Add(new LogItem($"Story {story.Title} created"));
        }
        public void CreateNewFeedback(Feedback feedback)
        {
            this.WorkItems.Add(feedback);
            this.activityHistory.Add(new LogItem($"Feedback {feedback.Title} created"));
        }
    }
}
