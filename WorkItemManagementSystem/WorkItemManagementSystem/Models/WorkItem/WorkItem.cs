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
                    throw new ArgumentNullException();//TODO
                }
                if (value.Length<10||value.Length>50)
                {
                    throw new ArgumentException();//TODO
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
                    throw new ArgumentNullException();//TODO
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException();//TODO
                }
                this.description = value;
            }
        }
    }
}
