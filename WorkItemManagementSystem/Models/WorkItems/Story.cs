using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Story : WorkItem, IStory
    {

        private List<Activity> activityHistory = new List<Activity>();

        public Story(string title)
        : base(title)
        {
            base.Тype = WorkItemType.Story;
        }

        public Story(string title, string description = "",PriorityType priority = PriorityType.None, StorySizeType size = StorySizeType.None, StoryStatus status = StoryStatus.None, List<IComment> comments = null, List<Activity> history = null)
            :base(title, description, comments, history)
        {
            this.Priority = priority;
            this.Size = size;
            this.StatusType = status;
        }

        public PriorityType Priority { get; set; }

        public StorySizeType Size { get; set; }

        public StoryStatus StatusType { get; set; }

        public WorkItemType Type { get; set; }

        public override void ChangePriority(PriorityType newPriority)
        {
            this.Priority = newPriority;
        }
        public override void ChangeSize(StorySizeType newType)
        {
            this.Size = newType;
        }
        public override void UpdateStoryStatus(StoryStatus newStatus)
        {
            this.StatusType = newStatus;
        }
    }
}

