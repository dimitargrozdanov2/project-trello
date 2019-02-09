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
        private List<LogItem> activityHistory = new List<LogItem>();


        public Team(string teamName)
        {
            this.TeamName = teamName;
            this.ActivityHistory.Add(new LogItem($"{teamName} created"));
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

        public List<LogItem> ActivityHistory
        {
            get
            {
                return this.activityHistory;
            }
        }



        public void AddMember(Person member)
        {
            this.members.Add(member);
            this.ActivityHistory.Add(new LogItem($"{member.UserName} added"));

        }

        public void CreateNewBoard(Board board)
        {
            this.boards.Add(board);
            this.ActivityHistory.Add(new LogItem($"{board.BoardName} created"));
        }

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
    }
}
