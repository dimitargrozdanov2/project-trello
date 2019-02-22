using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models.Contracts
{
    public interface IBoard
    {
        string BoardName { get; }
        List<WorkItem> WorkItems { get; }
        List<Activity> ActivityHistory { get;}
    }
}