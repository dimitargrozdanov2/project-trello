using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems;

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
            this.ActivityHistory.Add(new Activity($"{boardName} created"));
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

        public List<Activity> ActivityHistory
        {
            get
            {
                return new List<Activity>(this.activityHistory);
            }
        }

        public void CreateNewBug(Bug bug)
        {
            this.WorkItems.Add(bug);
            this.activityHistory.Add(new Activity($"Bug {bug.Title} created"));
        }

        public void CreateNewStory(Story story)
        {
            this.WorkItems.Add(story);
            this.activityHistory.Add(new Activity($"Story {story.Title} created"));
        }
        public void CreateNewFeedback(Feedback feedback)
        {
            this.WorkItems.Add(feedback);
            this.activityHistory.Add(new Activity($"Feedback {feedback.Title} created"));
        }
    }
}
