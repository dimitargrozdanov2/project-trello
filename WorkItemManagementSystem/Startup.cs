namespace WorkItemManagementSystem
{
    using Autofac;
    using System;
    using System.Linq;
    using System.Reflection;
    using WorkItemManagementSystem.Commands.Contracts;
    using WorkItemManagementSystem.Core;
    using WorkItemManagementSystem.Core.Contracts;

    class Staratup
    {
        static void Main(string[] args)
        {
            var config = new AutofacConfig();
            var container = config.Build();
            var engine = container.Resolve<IEngine>();
            engine.Start();
            
        }
    }
}
