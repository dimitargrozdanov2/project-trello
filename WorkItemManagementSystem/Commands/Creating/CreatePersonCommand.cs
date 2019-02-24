using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreatePersonCommand : Command, ICommand
    {

        public CreatePersonCommand(IFactory factory, IDataBase dataBase)
            : base(factory, dataBase)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string userName;
            string firstName;
            string lastName;

            try
            {
                userName = parameters[0];
                firstName = parameters[1];
                lastName = parameters[2];

            }
            catch
            {
                throw new ArgumentException("Failed to parse CreatePerson command parameters.");
            }

            var person = base.Factory.CreatePerson(userName, firstName, lastName);
            var people = base.DataBase.People;

            if (!people.ContainsKey(userName))
            {
                people.Add(userName, person);

                return ($" {person.FirstName} {person.LastName} with username: {person.UserName} was created.");

            }
            else
            {
                throw new ArgumentException($" {userName} already exists.");
            }
        }
    }
}
