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
        private WorkItemType type;

        //public Bug(string title):base(WorkItemType.Bug, title)
        //{
        //}

        //public Bug(string title,string priority, string severity, string bugStatus) :
        //   base(WorkItemType.Bug, title)
        //{
        //    this.Priority = priority.PriorityToEnum();
        //    this.Severity = severity.SeverityToEnum();
        //    this.BugStatus = bugStatus.BugStatusToEnum();
        //}

        public Bug(string title, string description = "", List<string> steps = null,
                                PriorityType priority = PriorityType.None, SeverityType severity = SeverityType.None, BugStatus bugStatus = BugStatus.None) :
            base(WorkItemType.Bug, title, description)
        {
            this.Steps = steps;
            this.Priority = priority;
            this.Severity = severity;
            this.BugStatus = bugStatus;
        }
        public WorkItemType Type
        {
            get
            {
                return this.type;
            }
        }

        public List<string> Steps { get; set; }

        public PriorityType Priority { get; set; }

        public SeverityType Severity { get; set; }

        public BugStatus BugStatus { get; set; }

        public long Id { get; set; }
    }
}
