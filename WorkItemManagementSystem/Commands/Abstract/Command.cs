using System.Collections.Generic;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Commands.Abstract
{
    public abstract class Command:ICommand
    {
        private readonly IFactory factory;
        private readonly IEngine engine;

        public Command(IFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public IFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public abstract string Execute(IList<string> parameters);
 
    }
}
