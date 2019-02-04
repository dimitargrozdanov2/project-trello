using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models
{
    class Teams : Team // All these methods can go in the Core.Factory
    {
        private List<Board> boards = new List<Board>(); // create lists of boards for all teams

        public List<Team> ShowAllMembers()
        {
            return new List<Team>(); // TO DO
        }
        public List<Team> ShowAllTeams()
        {
            return new List<Team>(); // TO DO
        }
        public Team CreateNewTeam()  // TO DO this must be in the factory
        {
            Team newTeam = new Team();
            return newTeam;
        }
    }
}
