using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models
{
    class Activity
    {
        private string description;
        private Member member;
        private DateTime time;

        public Activity(string description, Member member, DateTime time)
        {
            this.Description = description;
            this.Member = member;
            this.Time = time;
        }

        public string Description { get; private set; }
        public Member Member { get; private set; }
        public DateTime Time { get; private set; }
    }
   
}
