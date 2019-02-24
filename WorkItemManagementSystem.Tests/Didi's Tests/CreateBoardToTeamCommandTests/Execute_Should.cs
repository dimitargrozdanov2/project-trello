using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Commands.Creating;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.CreateBoardCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowException_WhenPassedInvalidParametersCount()
        {
            var expectedMessage = "Failed to parse CreateBoardToTeam command parameters.";
            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();

            var sut = new CreateBoardToTeamCommand(factoryMock.Object, databaseMock.Object);

            var ex = Assert.ThrowsException<ArgumentException>
                (() => sut.Execute(new List<string> { "a" }));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestMethod]
        public void ReturnMessage_WhenTeamNameNotExist()
        {
            var teams = new Dictionary<string, ITeam>();

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();

            databaseMock.SetupGet(x => x.Teams).Returns(teams);

            var sut = new CreateBoardToTeamCommand(factoryMock.Object, databaseMock.Object);
            var message = sut.Execute(new List<string> { "aaa", "alpha" });

            Assert.AreEqual($"alpha not exists.", message);
        }

        [TestMethod]
        public void ReturnMessage_WhenBoardNameAlreadyExists()
        {
            var boardName = "abcd";
            var teams = new Dictionary<string, ITeam>();

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();
            var boardMock = new Mock<IBoard>();
            var teamMock = new Mock<ITeam>();

            var boards = new List<IBoard> {boardMock.Object };
            teams.Add("alpha", teamMock.Object);

            databaseMock.SetupGet(x => x.Teams).Returns(teams);
            teamMock.Setup(b => b.Boards).Returns(boards);
            factoryMock.Setup(f => f.CreateBoard(boardName)).Returns(boardMock.Object);
            boardMock.Setup(b => b.BoardName).Returns(boardName);

            var sut = new CreateBoardToTeamCommand(factoryMock.Object, databaseMock.Object);
            var message = sut.Execute(new List<string> { boardName, "alpha" });

            Assert.AreEqual($" Board with name {boardName} already exists in alpha.", message);
        }

        [TestMethod]
        public void ReturnMessage_WhenBoardWasCraeted()
        {
            var boardName = "abcd";
            var teams = new Dictionary<string, ITeam>();
            var boards = new List<IBoard>();

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();
            var boardMock = new Mock<IBoard>();
            var teamMock = new Mock<ITeam>();

            teams.Add("alpha", teamMock.Object);

            databaseMock.SetupGet(x => x.Teams).Returns(teams);
            teamMock.Setup(b => b.Boards).Returns(boards);
            boardMock.Setup(b => b.BoardName).Returns(boardName);
            factoryMock.Setup(f => f.CreateBoard(boardName)).Returns(boardMock.Object);
            teamMock.Setup(t=>t.TeamName).Returns("alpha");

            var sut = new CreateBoardToTeamCommand(factoryMock.Object, databaseMock.Object);
            var message = sut.Execute(new List<string> { boardName, "alpha" });

            Assert.AreEqual($" Board {boardName} was created in alpha", message);
        }

    }
}
