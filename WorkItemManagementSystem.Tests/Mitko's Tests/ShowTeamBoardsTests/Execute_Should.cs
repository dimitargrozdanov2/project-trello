using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Listing;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Tests.Mitko_s_Tests.ShowTeamBoardsTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShowTeamBoards()
        {
            var teamName = "alpha";
            var parameters = new List<string> { teamName };


            var teams = new Dictionary<string, ITeam>();
            var dbMock = new Mock<IDataBase>();
            var boardMOck = new Mock<IBoard>();
            var teamMock = new Mock<ITeam>();
            var listboards = new List<IBoard>() {boardMOck.Object};
            dbMock.Setup(x => x.Teams).Returns(teams);
            teams.Add(teamName, teamMock.Object);
            teamMock.Setup(x => x.TeamName).Returns(teamName);
            teamMock.Setup(x => x.Boards).Returns(listboards);
            boardMOck.Setup(x => x.BoardName).Returns("Trello");
            var sut = new ShowTeamBoardsCommand(dbMock.Object);
            var message = sut.Execute(new List<string> { teamName});
            StringAssert.Contains(message, "* Trello");
        }
        [TestMethod]
        public void ThrowException_WhenInvalidParameters()
        {
       //     var teamName = "alpha";
            var parameters = new List<string>();
            var dbMock = new Mock<IDataBase>();
            var sut = new ShowTeamBoardsCommand(dbMock.Object);
            var ex = Assert.ThrowsException<ArgumentException>(() => sut.Execute(parameters));
            Assert.AreEqual("Failed to parse ShowTeamBoard command parameters.", ex.Message);

        }

    }
}
