using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItem.Contractes;

namespace WorkItemManagementSystem.Models.WorkItem
{
    class WorkItem:IWorkItem
    {
        private string title;
        private string description;

        public WorkItem(string title,string description)
        {
            this.Title = title;
            this.Description = description;
        }

       // public string Id => throw new NotImplementedException();

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Title cannot be empty");
                }
                if (value.Length<10||value.Length>50)
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
            set
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
    }
}
