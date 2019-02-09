using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        private List<string> stepsToReduce;

        public Feedback(string title) : base(title)
        {
        }

        public Feedback(string title, int rating, FeedbackStatus feedbackStatus) : base(title)
        {
            this.Rating = rating;
            this.FeedbackStatus = feedbackStatus;
        }


        public long Id { get; set; }

        public int Rating { get; }

        public FeedbackStatus FeedbackStatus { get; set; }
    }
}