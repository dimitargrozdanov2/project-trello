using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Models
{
    public interface ITeam
    {
        string TeamName { get; }
        //IList<Person> Members { get; }

        //IList<Board> Board { get; }
    }
}
