using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItems
{
    public class LogItem
    {
        public LogItem(string message)
        {
            this.Timestamp = DateTime.Now;
            this.Message = message;
        }

        public DateTime Timestamp { get; private set; }
        public string Message { get; private set; }

        public void Print()
        {
            Console.WriteLine($"[{this.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] {this.Message}");
        }
    }
}
