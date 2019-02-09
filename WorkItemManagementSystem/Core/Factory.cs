using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Core
{
    class Factory:IFactory
    {
        private static IFactory instanceHolder = new Factory();

        private Factory()
        {
        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public Person CreatePerson(string firstName,string lastName,string userName)
        {
            return new Person(firstName,lastName,userName);
        }

        public Team CreateTeam(string teamName)

        {
            return new Team(teamName);
        }
        
        public Board CreateBoard(string boardName)

        {
            return new Board(boardName);
        }

        public Bug CreateBug(string title)
        {
            return new Bug(title);
        }

        public Story CreateStory(string title)
        {
            return new Story(title);
        }

    }
}
