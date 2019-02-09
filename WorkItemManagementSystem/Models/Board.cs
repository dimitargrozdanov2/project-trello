using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.ExtentionMethods;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models
{
    public class Board
    {
        private string boardName;
        private List<WorkItem> workItems = new List<WorkItem>();
        private List<Activity> activityHistory = new List<Activity>();


        public Board(string boardName)
        {
            this.BoardName = boardName;
            this.activityHistory.Add(new Activity($"{boardName} created"));
        }

        public string BoardName
        {
            get
            {
                return this.boardName;
            }
            set
            {
                this.boardName = value.Validate("BoardName", 5, 15) ? value : throw new ArgumentException("");
            }
        }

        public List<IWorkItem> WorkItems { get; set; }

        public void CreateNewBug(Bug bug)
        {
            this.WorkItems.Add(bug);
            this.activityHistory.Add(new Activity($"{bug.Title} created"));
        }

        public void CreateNewStory(Story story)
        {
            this.WorkItems.Add(story);
            this.activityHistory.Add(new Activity($"{story.Title} created"));
        }
    }
}
