using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models
{
    public class Team : ITeam 
    {
        private string teamName;
        private IList<IPerson> members= new List<IPerson>();
        private IList<IBoard> boards = new List<IBoard>();
        private ICollection<Activity> activityHistory = new List<Activity>();


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

        public IList<IPerson> Members
        {
            get
            {
                return new List<IPerson>(this.members);
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
               return new List<IBoard>(this.boards);
            }
        }

        public ICollection<Activity> ActivityHistory
        {
            get
            {
                return new List<Activity>(this.activityHistory);
            }
        }


        public void AddMember(IPerson member)
        {
            this.members.Add(member);
            this.ActivityHistory.Add(new Activity($"{member.UserName} added"));

        }

        public void CreateNewBoard(IBoard board)
        {
            this.boards.Add(board);
            this.ActivityHistory.Add(new Activity($"{board.BoardName} created"));
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

        public  IBoard getBoardByName(string name)
        {
            int index = getBoardNames().IndexOf(name);
            return index < 0 ? null : Boards[index];
        }

        public List<string> getMembersNames()
        {
            List<string> membersNames = new List<string>();
            foreach (var member in Members)
            {
                membersNames.Add(member.UserName);
            }
            return membersNames;
        }

        public IPerson getMemberByName(string name)
        {
            int index = getMembersNames().IndexOf(name);
            return index < 0 ? null : Members[index];
        }
    }
}
