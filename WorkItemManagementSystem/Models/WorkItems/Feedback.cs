using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        private WorkItemType type;

        //assignee


        public Feedback(string title, string description = "", int rating = 0, FeedbackStatus feedbackStatus = FeedbackStatus.None, List<IComment> comments = null, List<Activity> history = null) 
                    : base(WorkItemType.Feedback, title, description, comments, history)
        {
            this.Rating = rating;
            this.FeedbackStatus = feedbackStatus;
        }

        public WorkItemType Type
        {
            get
            {
                return this.type;
            }
        }

        public long Id { get; set; }

        public int Rating { get; }

        public FeedbackStatus FeedbackStatus { get; set; }

    }
}