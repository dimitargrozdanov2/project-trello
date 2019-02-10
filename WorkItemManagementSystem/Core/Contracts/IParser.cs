using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Contracts;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
