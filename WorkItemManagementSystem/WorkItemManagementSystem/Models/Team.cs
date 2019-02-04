using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models
{
    class Team : ITeam // Dim, created Team
    {
        private string name;
        private List<Member> members = new List<Member>();
        private Board boards = new Board();
        // TO DO class Members

        public Team()
        {
        }
    }
}
