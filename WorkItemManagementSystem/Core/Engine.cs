﻿using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;
using WorkItemManagementSystem.Models.WorkItems;

namespace WorkItemManagementSystem.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;

        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        // private because of Singleton design pattern
        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();

            //this.Teams2 = new List<Team>();

            this.Teams = new Dictionary<string, Team>();
            this.People = new Dictionary<string, Person>();
            this.WorkItems = new Dictionary<long, WorkItem>();
        }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }

                return instanceHolder;
            }
        }

        // Property dependencty injection not validated for simplicity
        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public IDictionary<string, Team> Teams { get; private set; }

        public IDictionary<string, Person> People { get; private set; }

        public IDictionary<long, WorkItem> WorkItems { get; private set; }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}
