using System.Collections.Generic;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.WorkItems;


namespace WorkItemManagementSystem.Core
{
    public class Factory : IFactory
    {


        public Factory()
        {
        }


        public Person CreatePerson(string userName, string firstName, string lastName)
        {
            return new Person(userName, firstName, lastName);
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

        public Feedback CreateFeedback(string title)
        {
            return new Feedback(title);
        }

    }
}
