using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
