using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        //assignee

        public Feedback(string title) : base(title)
        {
            base.Тype = WorkItemType.Feedback;
        }

        public Feedback(string title, string description = "", int rating = 0, FeedbackStatus feedbackStatus = FeedbackStatus.None, List<IComment> comments = null, List<Activity> history = null) 
                    : base(title, description, comments, history)
        {
            this.Rating = rating;
            this.FeedbackStatus = feedbackStatus;
        }

        public int Rating { get; set; }

        public FeedbackStatus FeedbackStatus { get; set; }

        public WorkItemType Type { get; set; }

        public override void ChangeRating(int newRating)
        {
            this.Rating = newRating;
        }
        public override void UpdateFeedbackStatus(FeedbackStatus newStatus)
        {
            this.FeedbackStatus = newStatus;
        }

    }
}