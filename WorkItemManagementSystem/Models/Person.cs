﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.ExtentionMethods;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models
{
    public class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private string userName;
        private List<WorkItem> workItems = new List<WorkItem>();
        private ICollection<Activity> activityHistory = new List<Activity>();

        //public Person(string userName)
        //{
        //    this.UserName = userName;
        //    this.ActivityHistory.Add(new Activity($"{userName} created"));
        //}

        public Person(string userName, string firstName = "", string lastName = "")
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ActivityHistory.Add(new Activity($"{userName} created"));
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value.Validate("UserName", 5, 15) ? value : throw new ArgumentException("");
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value.Validate("FirstName", 0, 25) ? value : throw new ArgumentException("");
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value.Validate("LastName", 0, 25) ? value : throw new ArgumentException("");
            }
        }

        public List<WorkItem> WorkItems
        {
            get
            {
                return this.workItems;
            }
            private set
            {
                this.workItems = value;
            }
        }

        public ICollection<Activity> ActivityHistory
        {
            get
            {
                return this.activityHistory;
            }
        }

    }
}
