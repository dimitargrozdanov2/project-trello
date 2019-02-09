using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.ExtentionMethods;
using WorkItemManagementSystem.Models.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public abstract class WorkItem 
    {
        private WorkItemType type;
        private long id;
        private string title;
        private string description;
        private string status;

        public WorkItem(string title, string description) 
        {
            this.Title = title;
            this.Description = description;
            this.ID = IDGenerator.GetNextId();
        }
        public WorkItem(string title)
        {
            this.Title = title;
            this.ID = IDGenerator.GetNextId();
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
    }
}