using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Bug : WorkItem, IBug
    {
        private List<string> stepsToReduce;
        private List<LogItem> history = new List<LogItem>();

        public Bug(string title):base(title)
        {
        }

        public Bug(string title,string priority, string severity, string bugStatus) :
           base(title)
        {
            this.Priority = priority.PriorityToEnum();
            this.Severity = severity.SeverityToEnum();
            this.BugStatus = bugStatus.BugStatusToEnum();
        }
        public Bug(string title, string description, List<string> steps,
                                string priority, string severity, string bugStatus) :
            base(title,description)
        {
            this.Steps = steps;
            this.Priority = priority.PriorityToEnum();
            this.Severity = severity.SeverityToEnum();
            this.BugStatus = bugStatus.BugStatusToEnum();
        }


        public List<string> Steps { get; set; }

        public PriorityType Priority { get; set; }

        public SeverityType Severity { get; set; }

        public BugStatus BugStatus { get; set; }

        public List<LogItem> History
        {
            get
            {
                return new List<LogItem>(this.history);
            }
        }

        public long Id { get; set; }


        public void ChangePriority(PriorityType newType)
        {
            // TODO: WorkItem.Status must change only one step at a time
            this.Priority = newType;
            this.history.Add(new LogItem($"'{this.Title}' priority changed to {newType}"));
        }
    }
}
