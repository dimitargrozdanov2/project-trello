﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreateTeamCommand : Command, ICommand
    {

        public CreateTeamCommand(IFactory factory, IDataBase dataBase)
            : base(factory, dataBase)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string teamName;

            try
            {
                teamName = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }

            var teams = base.DataBase.Teams;


            if (!teams.ContainsKey(teamName))
            {
                var team = base.Factory.CreateTeam(teamName);
                teams.Add(teamName, team);

                return ($" Team {teamName} was created.");
            }
            else
            {
                throw new ArgumentException($" Team with name {teamName} alteady exists");
            }
           
        }
    }
}
