using Autofac;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WIMS.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private IComponentContext componentContext;

        public CommandParser(IComponentContext context)
        {
            this.componentContext = context;
        }

        public ICommand ParseCommand(string commandName)
        {
            var command = this.componentContext
                .ResolveNamed<ICommand>(commandName.ToLower());

            return command;
        }
    }
}
