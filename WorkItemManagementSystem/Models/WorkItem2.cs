using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Enums;
using WorkItemManagementSystem.Models.Extensions;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models
{
    public class WorkItem2
    {
        //private List<LogItem> activityHistory = new List<LogItem>();

        //public WorkItem(string title, string strType)
        //{
        //    this.Title = title;
        //    this.Type = strType.ToEnum();
        //}

        //public WorkItem(string title, WorkItemType type)
        //{
        //    this.Title = title;
        //    this.Type = type;
        //    this.Status = WorkItemStatus.NotStarted;
        //    this.activityHistory.Add(new LogItem($"--work item '{this.Title}' of type {this.Type} has been created"));
        //}

        //public string Title { get; set; }
        //public WorkItemType Type { get; private set; }
        //public WorkItemStatus Status { get; private set; }
        //public Member Owner { get; private set; }
        //public IEnumerable<LogItem> ActivityHistory
        //{
        //    get
        //    {
        //        // TODO: Improve WorkItem.ActivityHistory encapsulation
        //        return this.activityHistory;
        //    }
        //}

        //public void UpdateStatus(WorkItemStatus newStatus)
        //{
        //    // TODO: WorkItem.Status must change only one step at a time
        //    this.Status = newStatus;
        //    this.activityHistory.Add(new LogItem($"'{this.Title}' status changed to {newStatus}"));
        //}
        //public void UpdateAssignee(Member newAssignee)
        //{
        //    // TODO: Code smell
        //    this.Owner = newAssignee;
        //    this.activityHistory.Add(new LogItem($"'{this.Title}' has a new owner: {newAssignee.Name}"));
        //}
        //public void UpdateType(WorkItemType newType)
        //{
        //    // TODO: Code smell
        //    this.Type = newType;
        //}

        //public void Print()
        //{
        //    Console.WriteLine($"{this.Title}");
        //}
    }
}
