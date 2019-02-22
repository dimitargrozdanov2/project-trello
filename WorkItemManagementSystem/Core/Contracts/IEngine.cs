using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        IDictionary<string, Team> Teams { get; }

        IDictionary<string, Person> People { get; }

        IDictionary<long, WorkItem> WorkItems { get; }


    }

}
