using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.ExtentionMethods;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public abstract class WorkItem
    {
        private long id;
        private string title;
        private string description;
        private List<IComment> comments;
        private List<Activity> history;
        private Person assignee;

        // FIX the Constructors to one

        //public WorkItem(string title)
        //{
        //    this.Title = title;
        //    this.Id = IDGenerator.GetNextId();
        //    this.Assignee = assignee;
        //}

        public WorkItem(string title, string description = "", Person assignee = null, List<IComment> comments = null, List<Activity> history = null)
        {
            this.Title = title;
            this.Description = description;
            this.Id = IDGenerator.GetNextId();
            this.Comments = comments;
            this.History = history;
            this.Assignee = assignee;
        }


        public WorkItemType Тype { get; set; }

        public long Id { get; }

        public string Title
        {
            get
            {
                return this.title;
            }
            protected set
            {
                this.title = value.Validate("Title", 5, 50) ? value : throw new ArgumentException("");
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            protected set
            {
                this.description = value.Validate("Description", 10, 500) ? value : throw new ArgumentException("");
            }
        }

        public IPerson Assignee
        {
            get
            {
                return this.assignee;
            }
            set
            {
                this.assignee = value;
            }
        }

        public List<IComment> Comments
        {
            get
            {
                return this.comments;
            }
            protected set
            {
                this.comments = value;
            }
        }

        public List<Activity> History
        {
            get
            {
                return this.history;
            }
            protected set
            {
                this.history = value;
            }
        }



        public virtual void ChangePriority(PriorityType newPriority)
        {
        }
        public virtual void ChangeSeverity(SeverityType newSeverity)
        {
        }
        public virtual void UpdateBugStatus(BugStatus bugStatus)
        {
        }
        public virtual void ChangeSize(StorySizeType newType)
        {
        }
        public virtual void UpdateStoryStatus(StoryStatus storyStatus)
        {
        }
        public virtual void UpdateFeedbackStatus(FeedbackStatus newStatus)
        {
        }
        public virtual void ChangeRating(int newRating)
        {
        }
    }
}