using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Core.ExtentionMethods;

namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreatePersonCommand:Command,ICommand
    {

        public CreatePersonCommand(IFactory factory, IEngine engine)
            :base(factory,engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string firstName;
            string lastName;
            string userName;

            try
            {
                firstName = parameters[0];
                lastName = parameters[1];
                userName = parameters[2];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreatePerson command parameters.");
            }

            var person = base.Factory.CreatePerson(firstName,lastName,userName);
            var people = base.Engine.People;

            var sb = new StringBuilder();

            if (!people.ContainsKey(userName))
            {
                people.Add(userName, person );
                string msg = " {} {} with username: {} was created.".ReplaceBrakets(person.FirstName, person.LastName, person.UserName);
                //person.
                sb.AppendLine(msg);

                //sb.AppendLine($" {person.FirstName} {person.LastName} with username: {person.UserName} was created.");
            }
            else
            {
                sb.AppendLine($" {userName} already exists.");
            }
           

            return sb.ToString();
        }
    }
}
