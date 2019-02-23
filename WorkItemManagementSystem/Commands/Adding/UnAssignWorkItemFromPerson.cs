using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.WorkItems;
using WorkItemManagementSystem.Models.WorkItems.Contractes;

namespace WorkItemManagementSystem.Commands.Adding
{
    public class UnAssignWorkItemCommand : ICommand  // NZN
    {
        private IDataBase database;
        public UnAssignWorkItemCommand(IDataBase dataBase)
        {
            this.database = dataBase;
        }

        public string Execute(IList<string> parameters)
        {

            string userName;
            string workItem;
            double r;
            bool byId = false;

            try
            {
                workItem = parameters[0];
                userName = parameters[2];
                if (Double.TryParse(workItem, out r))
                {
                    byId = true;
                }
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignWorkItemToPerson command parameters.");
            }


            //var people = new List<Person>(base.Engine.People.Values);
            var people = this.database.People;
            var WorkItems = new List<WorkItem>(this.database.WorkItems.Values);



            if (!people.ContainsKey(userName))
            {
                return $"Person with the name {userName} has not been registered!\n";
            }
            else
            {
                var person = people[userName];
                var pwi = person.WorkItems; // list of Person's Work Items
                if (pwi == null || pwi.Count == 0)
                {
                    return $"Can not UNASSIGN! The Person {userName} ({person.FirstName} {person.LastName}) has no any WorkItems!\n";
                }
                else
                {
                    var i = 0;
                    WorkItem wi = null;
                    do
                    {
                        if (pwi[i].Title == workItem || (byId && pwi[i].Id == r))
                        {
                            wi = pwi[i];
                        }
                        if (wi == null) i++;
                    } while (wi == null && i < pwi.Count);
                    if (wi == null)
                    {
                        return $"Can not UNASSIGN! The WorkItem {workItem} is not assigned to {userName} ({person.FirstName} {person.LastName})!\n";
                    }
                    else
                    {
                        wi.Assignee = null;    //  member was UNassigned from the workItem wi
                        person.WorkItems.Remove(wi);   // workItem wi was removed from the list of workItems of that Person/Member 
                    }

                    string result = $" The {wi.Тype} \"{wi.Title}\" (Id: {wi.Id}) was UNassigned from {person.UserName} ({person.FirstName} {person.LastName})\n";
                    return result;
                }
            }
        }
    }
}

