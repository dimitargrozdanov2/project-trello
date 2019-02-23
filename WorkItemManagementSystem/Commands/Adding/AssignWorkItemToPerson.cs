using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AssignWorkItemCommand :  ICommand  // NZN
    {
        private IDataBase database;


        public AssignWorkItemCommand(IDataBase dataBase) 
        {
            this.database = dataBase;
        }

        public string Execute(IList<string> parameters)
        {

            string userName;
            string workItem;
            //double r;
            //bool byId = false; 

            try
            {
                workItem = parameters[0];
                userName = parameters[2];
                //if (Double.TryParse(workItem, out r))
                //{
                //    byId = true;
                //}
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignWorkItemToPerson command parameters.");
            }

            var teams = this.database.Teams;
            var people = this.database.People;
            var workitem = this.database.WorkItems;
            
            if (!people.ContainsKey(userName))
            {
                return $"Person with the name {userName} has not been registered!\n";
            }

            if (!workitem)
            else 
            {
                var t = 0;
                Person member = null;
                do
                {

                   member = this.database.Teams[t].getMemberByName(userName);
                    member = teams[t].getMemberByName(userName); 
                    if (member == null) t++;
                } while (member == null && t < teams.Count);
                if (member == null)
                {
                    return $"The Person {userName} does not belong to any team, thus it can not be assignee of any WorkItem!\n";
                }
                else
                {
                    var b = 0;
                    WorkItem wi = null;
                    var boards = this.database.Teams[t].Boards
                        teams[t].Boards;
                    do
                    {
                        if (byId)
                        {
                            wi = boards[b].GetWIbyID(r); // Get WorkItem by ID
                        } else
                        {
                            wi = boards[b].GetWIbyTitle(workItem);// Get WorkItem by NAME
                        }
                        if (wi == null) b++;
                    } while (wi == null && b < boards.Count);
                    if (wi == null)
                    {
                        return $"Can not ASSIGN! The WorkItem \"{workItem}\" does not belong to the team that the Person {userName} belongs to!\n";

                    } else
                    {
                        wi.Assignee = member;    //  member was assigned to the workItem wi
                        member.WorkItems.Add(wi);   // add workItem wi to the list of workItems of that Person/Member 
                        string result = $" The {wi.Тype} \"{wi.Title}\" (Id: {wi.Id}) was assigned to {member.UserName} ({member.FirstName} {member.LastName})\n";
                        return result;
                    }
                }
            }
        }
    }
}
