using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.WorkItems;


namespace WorkItemManagementSystem.Core
{
    class Factory : IFactory
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

        public Person CreatePerson(string userName,string firstName, string lastName)
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
        public Activity ShowPersonActivity(string message)
        {
            return new Activity(message);
        }

    }
}
