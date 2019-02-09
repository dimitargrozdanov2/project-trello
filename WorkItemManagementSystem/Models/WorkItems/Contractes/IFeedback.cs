﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IFeedback
    {
        int Rating { get; }
        FeedbackStatus feedbackStatus { get; }
    }
}