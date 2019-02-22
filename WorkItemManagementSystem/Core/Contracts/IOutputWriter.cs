using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface IOutputWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
