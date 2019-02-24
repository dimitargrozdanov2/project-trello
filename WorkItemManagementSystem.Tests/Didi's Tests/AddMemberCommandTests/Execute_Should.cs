using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Commands.Adding;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.AddMemberCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowException_WhenPassedInvalidParametersCount()
        {
            var expectedMessage = "Failed to parse AddMember command parameters.";
            var databaseMock = new Mock<IDataBase>();

            var parameters = new List<string>() { "userName","to" };

            var sut = new AddMemberCommand(databaseMock.Object);

            var ex = Assert.ThrowsException<ArgumentException>(() => sut.Execute(parameters));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestMethod]
        public void ReturnMessage_WhenTeamNameNotExist()
        {
            var teamName = "alpha";
            var parameters = new List<string>() { "userName", "to", teamName };

            var teams = new Dictionary<string, ITeam>();

            var databaseMock = new Mock<IDataBase>();
            var teamMock = new Mock<ITeam>();


            databaseMock.SetupGet(x => x.Teams).Returns(teams);

            var sut = new AddMemberCommand(databaseMock.Object);

            var message = sut.Execute(parameters);

            Assert.AreEqual($"{teamName} not exists.", message);
        }

        [TestMethod]
        public void ReturnMessage_WhenUserNameNotExist()
        {
            var userName = "didi89";
            var teamName = "alpha";

            var people = new Dictionary<string, IPerson>();
            var teams = new Dictionary<string, ITeam>();

            var databaseMock = new Mock<IDataBase>();

            var teamMock = new Mock<ITeam>();
            //var personMock = new Mock<IPerson>();

            databaseMock.SetupGet(x => x.Teams).Returns(teams);
            databaseMock.SetupGet(x => x.People).Returns(people);
            teams.Add(teamName, teamMock.Object);

            var sut = new AddMemberCommand(databaseMock.Object);

            var message = sut.Execute(new List<string>{userName, "to", teamName});

            Assert.AreEqual($"{userName} not exists.", message);
        }

        [TestMethod]
        public void ReturnMessage_WhenMemberWasAdded()
        {
            var userName = "didi89";
            var teamName = "alpha";
            var people = new Dictionary<string, IPerson>();
            var teams = new Dictionary<string, ITeam>();

            var databaseMock = new Mock<IDataBase>();
            var teamMock = new Mock<ITeam>();
            var personMock = new Mock<IPerson>();

            personMock.SetupGet(p => p.UserName).Returns(userName);
            databaseMock.SetupGet(x => x.Teams).Returns(teams);
            databaseMock.SetupGet(x => x.People).Returns(people);

            teams.Add(teamName, teamMock.Object);
            people.Add(userName, personMock.Object);        
            teams[teamName].AddMember(personMock.Object);

            var sut = new AddMemberCommand(databaseMock.Object);

            var message = sut.Execute(new List<string> { userName, "to", teamName });

            Assert.AreEqual($" {userName} was added to {teamName}", message);
        }
    }
}
