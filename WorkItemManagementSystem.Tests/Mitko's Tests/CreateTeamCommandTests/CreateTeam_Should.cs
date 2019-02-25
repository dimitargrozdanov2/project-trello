using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Creating;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models;

namespace WorkItemManagementSystem.Tests.Mitko_s_Tests
{
    [TestClass]
    public class CreateTeam_Should
    {
        [TestMethod]
        public void CreateTeam_TeamAlreadyExists()
        {
            var teamname = "teamX"; //setup key of the dictionary
            var factoryMock = new Mock<IFactory>();
            var dbMock = new Mock<IDataBase>();
            var teams = new Dictionary<string, ITeam>();  
            var teamMock = new Mock<ITeam>();
            teams.Add(teamname, teamMock.Object); // add team to the dictionary

            //Mock and Setup engine and db
            dbMock.Setup(x => x.Teams).Returns(teams);

            var sut = new CreateTeamCommand(factoryMock.Object, dbMock.Object);
            var parameters = new List<string> { "teamX" };
            var ex = Assert.ThrowsException<ArgumentException>(() => sut.Execute(parameters));
            Assert.AreEqual($" Team with name {teamname} alteady exists", ex.Message);

        }

        [TestMethod]
        public void CreateNewTeam_ChecksCount()
        {
            var teamname = "teamX";
            var factoryMock = new Mock<IFactory>();
            var dbMock = new Mock<IDataBase>();
            var teams = new Dictionary<string, ITeam>();
            var teamMock = new Mock<ITeam>();

            //Mock and Setup the engine and the db
            dbMock.Setup(x => x.Teams).Returns(teams);
            factoryMock.Setup(x => x.CreateTeam(teamname)).Returns(teamMock.Object);
            var sut = new CreateTeamCommand(factoryMock.Object, dbMock.Object);
            var parameters = new List<string> { "teamX" };
            sut.Execute(parameters);
            Assert.AreEqual(1, teams.Count);


        }
        [TestMethod]
        public void CreateNewTeam_CheckFormattedMessage()
        {
            var teamname = "teamX";
            var factoryMock = new Mock<IFactory>();
            var dbMock = new Mock<IDataBase>();
            var teams = new Dictionary<string, ITeam>();
            var teamMock = new Mock<ITeam>();

            dbMock.Setup(x => x.Teams).Returns(teams);
            factoryMock.Setup(x => x.CreateTeam(teamname)).Returns(teamMock.Object);
            var sut = new CreateTeamCommand(factoryMock.Object, dbMock.Object);
            var parameters = new List<string> { "teamX" };
            var message = sut.Execute(parameters);
            Assert.AreEqual(" Team teamX was created.", message);
        }
        [TestMethod]
        public void ThrowExceptionWithInvalidParameters()
        {
            var factoryMock = new Mock<IFactory>();
            var dbMock = new Mock<IDataBase>();

            var sut = new CreateTeamCommand(factoryMock.Object, dbMock.Object);
            Assert.ThrowsException<ArgumentException>
                (() => sut.Execute(new List<string> {  }));
        }
    }
}
