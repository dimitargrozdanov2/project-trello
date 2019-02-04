using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItem.Enums;

namespace WorkItemManagementSystem.Models.WorkItem.Contractes
{
    class IFeedback
    {
        int Rating { get; }
        FeedbackStatus feedbackStatus { get; }
    }
}
