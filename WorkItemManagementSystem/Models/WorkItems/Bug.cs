using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Bug : WorkItem, IBug
    {
        private List<string> steps;
        private Person assignee;

        //public Bug(string title) : base(title)
        //{
        //    base.Тype = WorkItemType.Bug;
        //}

        public Bug(string title, string description = "description", List<string> steps = null,
                                PriorityType priority = PriorityType.None, SeverityType severity = SeverityType.None, BugStatus bugStatus = BugStatus.None, Person assignee = null, List<IComment> comments  = null, List<Activity> history = null) :
            base(title, description, assignee, comments, history)
        {
            base.Тype = WorkItemType.Bug;
            this.Steps = steps;
            this.Priority = priority;
            this.Severity = severity;
            this.BugStatus = bugStatus;
        }

        public List<string> Steps
        {
            get
            {
                return this.steps;
            }
            set
            {
                this.steps = value;
            }
        }
        
        public PriorityType Priority { get; set; }

        public SeverityType Severity { get; set; }

        public BugStatus BugStatus { get; set; }

        public WorkItemType Type { get; set; }

        public override void ChangePriority(PriorityType newPriority)
        {
            // TODO: WorkItem.Status must change only one step at a time
            this.Priority = newPriority;
            //this.History.Add(new Activity($"'{this.Title}' status changed to {newPriority}"));
        }
        public override void ChangeSeverity(SeverityType newSeverity)
        {
            this.Severity = newSeverity;
            //this.History.Add(new Activity($"'{this.Title}' status changed to {newSeverity}"));
        }
        public override void UpdateBugStatus(BugStatus newStatus)
        {
            this.BugStatus = newStatus;
            //this.History.Add(new Activity($"'{this.Title}' status changed to {newStatus}"));
        }
    }
}
