using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Comment : IComment
    {
        private string message;
        private IPerson author;

        public Comment(string message, Person author)
        {
            this.Message = message;
            this.Author = author;
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
        public IPerson Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
    }
}
