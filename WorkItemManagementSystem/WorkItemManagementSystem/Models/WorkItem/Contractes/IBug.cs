using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItem.Enums;

namespace WorkItemManagementSystem.Models.WorkItem.Contractes
{
    interface IBug: IWorkItem
    {
        List<string> Steps { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatus BugStatus { get; }
        //asignee???

    }
}
