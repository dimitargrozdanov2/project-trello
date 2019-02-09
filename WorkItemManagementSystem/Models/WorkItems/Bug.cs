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

        public long Id { get; set; }
    }
}
