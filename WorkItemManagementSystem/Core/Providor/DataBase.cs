using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Core.Providor
{
    public class DataBase : IDataBase
    {
        public DataBase()
        {
            this.People = new Dictionary<string ,IPerson>();
            this.Teams = new Dictionary<string, ITeam>();
            this.WorkItems = new Dictionary<long, WorkItem>();
        }


        public IDictionary<string, ITeam> Teams { get; private set; }

        public IDictionary<string, IPerson> People { get; private set; }

        public IDictionary<long, WorkItem> WorkItems { get; private set; }
    }
}
