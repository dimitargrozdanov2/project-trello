using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItem.Enums;

namespace WorkItemManagementSystem.Models.WorkItem.Contractes
{
    interface IStory:IWorkItem
    {
        PriorityType priority { get; }
        SizeType size { get; }
        StoryStatus statusType { get; }
        //asigneee
    }
}
