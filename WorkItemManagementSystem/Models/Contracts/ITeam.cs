
using System.Collections.Generic;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Models
{
    public interface ITeam
    {
        string TeamName { get; }
        IList<Person> Members { get; }

        IList<Board> Board { get; }
        void AddMember(IPerson member);
        void CreateNewBoard(IBoard board);
    }
}
