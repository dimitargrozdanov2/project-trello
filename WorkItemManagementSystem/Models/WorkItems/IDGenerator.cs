using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.WorkItems
{
    static class IDGenerator // Dim added IDGenerator for unique IDs.
    {
        private static long nextId = 1;
        public static long GetNextId()
        {
            return nextId++;
        }
    }
}
