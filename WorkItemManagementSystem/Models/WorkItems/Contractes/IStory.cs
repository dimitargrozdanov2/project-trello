﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IStory : IWorkItem
    {
        PriorityType Priority { get; }
        StorySizeType Size { get; }
        StoryStatus StatusType { get; }
        //asigneee
    }
}
