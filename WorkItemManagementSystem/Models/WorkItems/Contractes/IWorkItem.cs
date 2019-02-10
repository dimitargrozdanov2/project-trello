using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IWorkItem
    {
        //WorkItemType type { get; }
        long Id { get; }
        string Title { get; }
        string Description { get; }
        //Coments;???
        //History;???
    }
}
