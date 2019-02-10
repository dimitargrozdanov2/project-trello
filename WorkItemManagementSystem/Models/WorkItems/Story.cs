using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class Story : WorkItem, IStory
    {
       
        //public Story(string title)
        //: base(title)
        //{
        //} 

        //assignee
        public Story(string title, string description = "",PriorityType priority = PriorityType.None, StorySizeType size = StorySizeType.None, StoryStatus status = StoryStatus.None)
            :base(WorkItemType.Story, title,description)
        {
            this.Priority = priority;
            this.Size = size;
            this.StatusType = status;
        }
        
        public PriorityType Priority { get; set; }

        public StorySizeType Size { get; set; }

        public StoryStatus StatusType { get; set; }

        public long Id { get; set; }
    }
}
