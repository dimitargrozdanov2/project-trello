using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IFeedback : IWorkItem
    {
        int Rating { get; }
        FeedbackStatus FeedbackStatus { get; }
    }
}
