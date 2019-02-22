using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Core.Providor
{
    public class ConsoleWriter:IOutputWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
