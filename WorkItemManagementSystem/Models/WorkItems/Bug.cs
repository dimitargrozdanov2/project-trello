using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Bug : WorkItem, IBug
    {
        private WorkItemType type;
        private List<string> steps;

        //assignee

        public Bug(string title, string description = "", List<string> steps = null,
                                PriorityType priority = PriorityType.None, SeverityType severity = SeverityType.None, BugStatus bugStatus = BugStatus.None, List<IComment> comments  = null, List<Activity> history = null) :
            base(WorkItemType.Bug, title, description, comments, history)
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
