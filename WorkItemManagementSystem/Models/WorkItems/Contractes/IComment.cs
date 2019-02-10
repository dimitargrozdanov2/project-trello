using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Models.WorkItems.Contractes
{
    public interface IComment
    {
        string Message { get; set; }
        IPerson Author { get; set; }
    }
}
