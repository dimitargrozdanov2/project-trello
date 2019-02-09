using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementSystem.Commands.Abstract;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models.Enums;
using WorkItemManagementSystem.Models.Extensions;

namespace WorkItemManagementSystem.Commands.Creating
{
    public class CreateBugInBoardCommand 
    {
        //public CreateBugInBoardCommand(IFactory factory, IEngine engine)
        //   : base(factory, engine)
        //{
        //}

        //public override string Execute(IList<string> parameters)
        //{
        //    string workItem;
        //    string title;
        //    string boardName;
        //    string teamName;

        //    try
        //    {
        //        workItem = parameters[0];
        //        title = parameters[1];
        //        boardName = parameters[2];
        //        teamName = parameters[3];
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Failed to parse CreateBug command parameters.");
        //    }


        //    var teams = base.Engine.Teams;

        //    if (!teams.ContainsKey(teamName))
        //    {
        //        return $"{teamName} not exists.";
        //    }
        //    var team = teams[teamName];
        //    var boards = team.Boards;

        //    var board =

        //    var sb = new StringBuilder();
        //    workItem = workItem.ToLower();
        //    switch (workItem)
        //    {
        //        case "bug":

        //            var bug = base.Factory.CreateBug(title);
        //            board.Create

        //            break;
        //        case "story":
        //            var story = base.Factory.CreateStory(title);
        //            break;

        //        default:
        //            return "There is no workItemType";
        //    }
        //}
    }
}
