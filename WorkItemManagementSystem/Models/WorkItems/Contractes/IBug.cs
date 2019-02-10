using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IBug: IWorkItem
    {
        //WorkItemType Type { get ; }
        List<string> Steps { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatus BugStatus { get; }

        //TODO
        //asignee???

    }
}
