using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Contracts;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandName);
    }
}
