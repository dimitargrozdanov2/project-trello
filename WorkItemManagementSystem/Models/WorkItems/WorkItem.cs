using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.ExtentionMethods;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public abstract class WorkItem 
    {
        private WorkItemType type;
        private long id;
        private string title;
        private string description;
        private List<IComment> comments;
        private List<Activity> history;

        public WorkItem(WorkItemType type, string title, string description="", List<IComment> comments = null, List<Activity> history = null) 
        {
            this.Title = title;
            this.Description = description;
            this.ID = IDGenerator.GetNextId();
            this.Comments = comments;
            this.History = history;
        }

        public WorkItemType Тype
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public long ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
           protected  set
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
    }
}