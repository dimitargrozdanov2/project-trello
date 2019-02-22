using System.Collections.Generic;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Core.Providor
{
    public interface IDataBase
    {
        IDictionary<string, IPerson> People { get; }
        IDictionary<string, ITeam> Teams { get; }
        IDictionary<long, WorkItem> WorkItems { get; }
    }
}