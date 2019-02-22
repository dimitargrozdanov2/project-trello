using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Adding
{
    class CreateBoardToTeamCommand : Command, ICommand
    {

        public CreateBoardToTeamCommand(IFactory factory, IDataBase dataBase) : base(factory, dataBase)
        {
        }

        public override string Execute(IList<string> parameters)
        {

            string boardName;
            string teamName;

            try
            {
                boardName = parameters[0];
                teamName = parameters[1];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBoardToTeam command parameters.");
            }


            var teams = base.DataBase.Teams;

            if (!teams.ContainsKey(teamName))
            {
                return $"{teamName} not exist";
            }

            var team = teams[teamName];
            var boards = team.Boards;
            var board = base.Factory.CreateBoard(boardName);
            team.CreateNewBoard(board);

            foreach (var bord in boards)
            {
                if (bord.BoardName == boardName)
                {
                    return $" Board with name {bord.BoardName} already exists in {teamName}.";
                }
            }

            string result = $" Board {board.BoardName} was created in {team.TeamName}";

            return result;
        }
    }
}

