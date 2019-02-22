using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models
{
    public class Board
    {
        private string boardName;
        private List<WorkItem> workItems = new List<WorkItem>();
        private readonly List<Activity> activityHistory = new List<Activity>();


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
        //public List<string> GetStoryNames() //  Dim & Co - можех да го направя по ID, но нямаше да е удобно заради човешкия фактор
        //{
        //    List<string> storynames = new List<string>();
        //    foreach (var story in WorkItems)
        //    {
        //        storynames.Add(story.Title);
        //    }
        //    return storynames;
        //}

        //public WorkItem GetStoryByName(string name)
        //{
        //    int index = GetStoryNames().IndexOf(name);
        //    return index < 0 ? null : workItems[index];
        //}

        //public List<string> GetBugNames()
        //{
        //    List<string> bugnames = new List<string>();
        //    foreach (var bug in WorkItems)
        //    {
        //        bugnames.Add(bug.Title);
        //    }
        //    return bugnames;
        //}

        //public WorkItem GetBugByName(string name)
        //{
        //    int index = GetBugNames().IndexOf(name);
        //    return index < 0 ? null : workItems[index];
        //}

        //public List<string> GetFeedbackNames()
        //{
        //    List<string> feedbacknames = new List<string>();
        //    foreach (var feedback in WorkItems)
        //    {
        //        feedbacknames.Add(feedback.Title);
        //    }
        //    return feedbacknames;
        //}

        //public WorkItem GetFeedbackByName(string name)
        //{
        //    int index = GetFeedbackNames().IndexOf(name);
        //    return index < 0 ? null : workItems[index];
        //}

        //public List<double> GetWIbyID()
        //{
        //    List<double> IDs = new List<double>();
        //    foreach (var workitem in WorkItems)
        //    {
        //        IDs.Add(workitem.ID);
        //    }
        //    return IDs;
        //}
        //public WorkItem GetWIbyID(double ID)
        //{
        //    int index = GetWIbyID().IndexOf(ID);
        //    return index < 0 ? null : workItems[index];
        //}
    }
}
