using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models
{
    //public class Member : Person, IMember
    //{

    //    private List<IWorkItem> workItems = new List<IWorkItem>();
    //    private List<Activity> activityHistory = new List<Activity>();

    //    public Member(string userName )
    //        :base(userName)
    //    {
    //        this.activityHistory.Add(new Activity($"{userName} created"));
    //    }

    //    public Member(string userName, IEnumerable<WorkItem> workItems):this(userName)
    //    {
    //        this.workItems = new List<IWorkItem>(workItems);
    //        // TODO: Use ForEach
    //        foreach (var item in workItems)
    //        {
    //            this.activityHistory.Add(new Activity($"{item.Title} created"));
    //        }
    //    }

    //    //public IEnumerable<WorkItem> WorkItems
    //    //{
    //    //    get
    //    //    {
    //    //        // TODO: Improve Team.WorkItems encapsulation
    //    //        return this.workItems;
    //    //    }
    //    //}
    //    public IEnumerable<Activity> ActivityHistory { get; private set; }
       


    //    //public void AddWorkItem(WorkItem workItem)
    //    //{
    //    //    this.workItems.Add(workItem);
    //    //    this.activityHistory.Add(new Activity($"{workItem} added to {this.Name}"));
    //    //}

    //}

}

