using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public abstract class WorkItem 
    {
        private string title;
        private string description;
        private long id;

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
                if (value == null)
                {
                    throw new ArgumentNullException("Title cannot be empty");
                }
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Title must be between 10 and 50 characters");
                }
                this.title = value;
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
                if (value == null)
                {
                    throw new ArgumentNullException("Description cannot be empty");
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentOutOfRangeException("Description must be between 10 and 50 characters");
                }
                this.description = value;
            }
        }

        public long ID  // Dim 
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