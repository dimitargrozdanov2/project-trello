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

        void CreateNewBug(Bug bug);
        void CreateNewStory(Story story);
        void CreateNewFeedback(Feedback feedback);
        WorkItem GetWIbyTitle(string title);
        WorkItem GetWIbyID(double ID);


    }
}