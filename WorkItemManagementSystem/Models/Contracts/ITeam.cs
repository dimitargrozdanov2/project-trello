
using System.Collections.Generic;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Models
{
    public interface ITeam
    {
        string TeamName { get; }
        IList<IPerson> Members { get; }
        IList<IBoard> Boards { get; }
        void AddMember(IPerson member);
        void CreateNewBoard(IBoard board);
    }
}
