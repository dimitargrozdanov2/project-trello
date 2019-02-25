using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models
{
    public class Board:IBoard
    {
        private string boardName;
        private readonly IList<WorkItem> workItems = new List<WorkItem>();
        private readonly ICollection<Activity> activityHistory = new List<Activity>();


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
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.boardName = value;
            }
        }

        public IList<WorkItem> WorkItems
        {
            get
            {
                return this.workItems;
            }
        }

        public ICollection<Activity> ActivityHistory
        {
            get
            {
                return this.activityHistory;
            }
        }

        public void CreateNewBug(Bug bug)
        {
            this.WorkItems.Add(bug);
            this.ActivityHistory.Add(new Activity($"Bug {bug.Title} created"));
        }

        public void CreateNewStory(Story story)
        {
            this.WorkItems.Add(story);
            this.ActivityHistory.Add(new Activity($"Story {story.Title} created"));
        }
        public void CreateNewFeedback(Feedback feedback)
        {
            this.WorkItems.Add(feedback);
            this.ActivityHistory.Add(new Activity($"Feedback {feedback.Title} created"));
        }

        ////

        public List<string> GetWITitles()
        {
            List<string> titles = new List<string>();
            foreach (var workitem in WorkItems)
            {
                titles.Add(workitem.Title);
            }
            return titles;
        }

        public WorkItem GetWIbyTitle(string title)
        {
            int index = GetWITitles().IndexOf(title);
            return index < 0 ? null : workItems[index];
        }

        public List<double> GetWIIDs()
        {
            List<double> IDs = new List<double>();
            foreach (var workitem in WorkItems)
            {
                IDs.Add(workitem.Id);
            }
            return IDs;
        }

        public WorkItem GetWIbyID(double ID)
        {
            int index = GetWIIDs().IndexOf(ID);
            return index < 0 ? null : workItems[index];
        }
    }
}
