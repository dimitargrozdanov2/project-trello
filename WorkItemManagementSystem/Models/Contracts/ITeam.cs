
using System.Collections.Generic;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Models
{
    public interface ITeam
    {
        string TeamName { get; }
        IList<IPerson> Members { get; }
        IList<IBoard> Boards { get; }
        ICollection<Activity> ActivityHistory { get; }

        void AddMember(IPerson member);
        void CreateNewBoard(IBoard board);
        IPerson getMemberByName(string name);
    }
}
