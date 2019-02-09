namespace WorkItemManagementSystem
{
    using System;
    using WorkItemManagementSystem.Core;

    class Staratup
    {
        static void Main(string[] args)
        {
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
