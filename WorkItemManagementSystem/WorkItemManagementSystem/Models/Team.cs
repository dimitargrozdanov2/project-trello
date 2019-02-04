using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models
{
    class Team : ITeam // Dim, created Team
    {
        private string name;
        private List<Member> members = new List<Member>();
        // TO DO class Members
        private List<Board> teamBoards = new List<Board>();

        public Team(string name, List<Member> members, List<Board> teamBoards)
        {
            this.name = name;
            this.members = members;
            this.TeamBoards = teamBoards;
        }
        public List<Board> TeamBoards
        {
            get
            {
                this.teamBoards;
            }
         

        }

       

        public List<Member> ShowAllMembers()
        {
            return new List<Member>(); // To DO
        }
        public Activity ShowActivity(Member member) // show activity history of each team member, also need to define Activity
        {
          //  return member.ActivityHistory(); // need to implement constructors
        }
        public Board CreateNewBoard() // TO DO
        {
            return  boards.Add(new Board()); // new board will be added to the list of boards
        }
        public List<Board> ShowAllBoards() // show all boards of this.team
        {
            return TeamBoards; // To Do , need to implement property with only getter
        }

    }
}
