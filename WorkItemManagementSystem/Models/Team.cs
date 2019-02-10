using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models
{
    public class Team : ITeam // Dim, created Team
    {
        private string teamName;
        private IList<Person> members= new List<Person>();
        private List<Board> boards = new List<Board>();
        private List<Activity> activityHistory = new List<Activity>();


        public Team(string teamName)
        {
            this.TeamName = teamName;
            this.ActivityHistory.Add(new Activity($"{teamName} created"));
        }


        public string TeamName
        {
            get
            {
                return this.teamName;
            }
            set
            {
                this.teamName = value;
            }
        }

        public IList<Person> Members => new List<Person>(this.members);

        public List<Board> Boards
        {
            get
            {
               return new List<Board>(this.boards);
            }
        }

        public List<Activity> ActivityHistory
        {
            get
            {
                return this.activityHistory;
            }
        }



        public void AddMember(Person member)
        {
            this.members.Add(member);
            this.ActivityHistory.Add(new Activity($"{member.UserName} added"));

        }

        public void CreateNewBoard(Board board)
        {
            this.boards.Add(board);
            this.ActivityHistory.Add(new Activity($"{board.BoardName} created"));
        }
<<<<<<< HEAD

        //TODO
        public string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Members in {teamName}:");
            foreach (var member in members)
            {
                sb.AppendLine($"{member.UserName} {member.LastName}");
            }
            return sb.ToString();
        }
        public List<string> getBoardNames()
        {
            List<string> boardnames = new List<string>();
            foreach (var board in Boards)
            {
                boardnames.Add(board.BoardName);
            }
            return boardnames;
        }

        public  Board getBoardByName(string name)
        {
            int index = getBoardNames().IndexOf(name);
            return index < 0 ? null : Boards[index];
        }
=======
>>>>>>> 86afc722df523769f3927203f91c62f303b4a576
    }
}
