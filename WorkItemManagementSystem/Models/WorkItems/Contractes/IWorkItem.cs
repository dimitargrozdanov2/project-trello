using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IWorkItem
    {
        long Id { get; }
        string Title { get; }
        string Description { get; }
        //Coments;???
        //History;???
    }
}
