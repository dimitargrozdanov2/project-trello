using System;
using System.Linq;
using WorkItemManagementSystem.Core.Contracts;

namespace WIMS.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser commandParser;
        private readonly IInputProvider inputProvider;
        private readonly IOutputWriter outputWriter;

        public Engine(IInputProvider inputProvider, IOutputWriter outputWriter, ICommandParser commandParser)

        {
            this.commandParser = commandParser;
            this.inputProvider = inputProvider;
            this.outputWriter = outputWriter;
        }

        public virtual void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.inputProvider.ReadLine();

                    if (commandAsString.ToLower() == "end")
                    {
                        break;
                    }
                    var lineParameters = commandAsString.Trim().Split(
                        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var commandName = lineParameters[0];
                    var parameters = lineParameters.Skip(1);

                    var command = this.commandParser.ParseCommand(commandName);
                    var output = command.Execute(parameters.ToList());

                    this.outputWriter.WriteLine(output);
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.outputWriter.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}

