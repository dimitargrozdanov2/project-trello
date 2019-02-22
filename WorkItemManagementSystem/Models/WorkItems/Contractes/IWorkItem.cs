using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IWorkItem
    {
        WorkItemType Type { get;}
        long Id { get; }
        string Title { get; }
        string Description { get; }
        Person Assignee { get; }

        //List<IComment> Coments { get; }
        //List<Activity> History { get; }
    }
}
