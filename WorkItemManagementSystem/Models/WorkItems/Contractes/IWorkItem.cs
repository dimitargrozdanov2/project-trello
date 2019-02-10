using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IWorkItem
    {
        long Id { get; }
        string Title { get; }
        string Description { get; }
        WorkItemType Type { get;}

        //List<IComment> Coments { get; }
        //List<Activity> History { get; }
    }
}
