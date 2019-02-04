using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models
{
    class Member
    {
       private string name;

        public Member(string name)
        {
            this.name = name;
        }
        public List<Activity> ActivityHistory() // TO DO
        {
            return new List<Activity>();
        }
        public Member AddMember()
        {
            //   return new Member(); // To DO
        }
    }
}
