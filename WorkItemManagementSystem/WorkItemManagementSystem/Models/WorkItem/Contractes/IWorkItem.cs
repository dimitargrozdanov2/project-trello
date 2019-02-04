using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItem.Contractes
{
    interface IWorkItem
    {
        //Type of Id????
        //string Id { get; }
        string Title { get; }
        string Description { get; }
        //Coments;???
        //History;???
    }
}
