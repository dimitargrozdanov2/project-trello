using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Models
{
    public class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private string userName;

        public Person(string userName)
        {
            this.UserName = userName;
        }

        public Person(string userName, string firstName, string lastName)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        //TODO: validate firstName and lastName
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException();//TODO
                }

                this.userName = value;
            }
        }
    }
}
