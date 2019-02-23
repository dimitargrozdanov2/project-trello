using System.Collections.Generic;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Models.Contracts
{
    public interface IBoard
    {
        string BoardName { get; }
        List<WorkItem> WorkItems { get; }
        List<Activity> ActivityHistory { get;}

        void CreateNewBug(IBug bug);
        void CreateNewStory(IStory story);
        void CreateNewFeedback(Feedback feedback);
        void GetWIbyTitle(string title);
        void GetWIbyID(double ID);


    }
}