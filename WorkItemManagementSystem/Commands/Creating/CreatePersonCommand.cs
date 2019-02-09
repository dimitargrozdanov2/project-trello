namespace WorkItemManagementSystem.Commands.Creating
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WorkItemManagementSystem.Commands.Abstract;
    using WorkItemManagementSystem.Commands.Contracts;
    using WorkItemManagementSystem.Core.Contracts;

    public class CreatePersonCommand : Command, ICommand
    {

        public CreatePersonCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
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

            var person = base.Factory.CreatePerson(userName,firstName, lastName);
            var people = base.Engine.People;

            var sb = new StringBuilder();

            if (!people.ContainsKey(userName))
            {
                people.Add(userName, person);
                sb.AppendLine($" {person.FirstName} {person.LastName} with username: {person.UserName} was created.");
            }
            else
            {
                sb.AppendLine($" {userName} already exists.");
            }


            return sb.ToString();
        }
    }
}
