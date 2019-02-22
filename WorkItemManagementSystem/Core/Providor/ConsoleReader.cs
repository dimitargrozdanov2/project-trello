using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Core.Providor
{
    public class ConsoleReader :IInputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
