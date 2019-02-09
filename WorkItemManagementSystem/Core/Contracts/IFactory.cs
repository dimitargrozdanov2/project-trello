using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface IFactory
    {
        Team CreateTeam(string teamName);

        Person CreatePerson(string firstName, string lastName, string userName);
        Board CreateBoard(string boardName);


        Bug CreateBug(string title);
        Story CreateStory(string title);


    }
}
