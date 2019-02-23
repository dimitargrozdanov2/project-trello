using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IWorkItem
    {
        WorkItemType Type { get;}
        long Id { get; }
        string Title { get; }
        string Description { get; }
        IPerson Assignee { get; }

        //List<IComment> Coments { get; }
        //List<Activity> History { get; }
    }
}
