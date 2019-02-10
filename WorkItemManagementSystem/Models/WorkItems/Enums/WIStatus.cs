using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItems.Enums
{
    //public class WIStatus
    //{
    //    private BugStatus bugStatus;
    //    private FeedbackStatus feedbackStatus;
    //    private StoryStatus storyStatus;

    //    public WIStatus(BugStatus bugStatus, FeedbackStatus feedbackStatus, StoryStatus storyStatus)
    //    {
    //        this.bugStatus = bugStatus;
    //        this.feedbackStatus = feedbackStatus;
    //        this.storyStatus = storyStatus;
    //    }
    //}

    public enum WIStatus
    {
        None//,

        Active,
        Fixed,

        New,
        Unscheduled,
        Scheduled,

        NotDone,
        InProgress,
        Done
    }
}
