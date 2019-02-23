using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models.Contracts
{
    public interface IPerson
    {
        string UserName { get; }
        string FirstName { get; }
        string LastName { get; }

        ICollection<Activity> ActivityHistory { get; }

    }
}
