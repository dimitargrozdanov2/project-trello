using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Story : WorkItem, IStory
    {

        private List<Activity> activityHistory = new List<Activity>();

        //assignee

        public Story(string title, string description = "",PriorityType priority = PriorityType.None, StorySizeType size = StorySizeType.None, StoryStatus status = StoryStatus.None, List<IComment> comments = null, List<Activity> history = null)
            :base(WorkItemType.Story, title, description, comments, history)
        {
            this.Priority = priority;
            this.Size = size;
            this.StatusType = status;
        }
        
        public PriorityType Priority { get; set; }

        public StorySizeType Size { get; set; }

        public StoryStatus StatusType { get; set; }

        public long Id { get; set; }

        public void ChangePriority(PriorityType newPrio)
        {
            // TODO: WorkItem.Status must change only one step at a time
            this.Priority = newPrio;
            this.activityHistory.Add(new Activity($"'{this.Priority}' status changed to {newPrio}"));
        }
        //public void ChangeSize(Member newAssignee)
        //{
        //    // TODO: Code smell
        //    this.Owner = newAssignee;
        //    this.activityHistory.Add(new LogItem($"'{this.Title}' has a new owner: {newAssignee.Name}"));
        //}
        //public void ChangeStatus(WorkItemType newType)
        //{
        //    // TODO: Code smell
        //    this.Type = newType;
        //}
      
    }
}
