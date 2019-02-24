using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Commands.Listing;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.ShowTeamCommand
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnMessage_WhenNoRegistredTeams()
        {
            var parameters = new List<string>();
            var teams = new Dictionary<string, ITeam>();
            var databaseMock = new Mock<IDataBase>();

            databaseMock.Setup(d => d.Teams).Returns(teams);

            var sut = new ShowTeamsCommand(databaseMock.Object);
            var message = sut.Execute(parameters);

            Assert.AreEqual(" There are no registered teams.", message);
        }

        [TestMethod]
        public void ShowAllTeams()
        {
            var parameters = new List<string>();
            var teams = new Dictionary<string, ITeam>();
            var databaseMock = new Mock<IDataBase>();
            var teamMock = new Mock<ITeam>();

            teams.Add("alpha", teamMock.Object);
            teams.Add("beta", teamMock.Object);
            databaseMock.Setup(d => d.Teams).Returns(teams);

            var sut = new ShowTeamsCommand(databaseMock.Object);
            var message = sut.Execute(parameters);

            StringAssert.Contains(message, "* alpha");
            StringAssert.Contains(message, "* beta");
        }
    }
}
