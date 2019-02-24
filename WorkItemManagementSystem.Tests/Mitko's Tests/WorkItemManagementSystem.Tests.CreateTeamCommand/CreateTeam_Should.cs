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
            //Act
            var MockFactory = new Mock<IFactory>();
            var MockDB = new Mock<IDataBase>();

            //Mock and Setup the team
            var parameters = new List<string> { "alpha" }; // alpha is team name 
            var TeamMock = new Mock<ITeam>();      // създавам fake теам
            TeamMock.Setup(x => x.TeamName).Returns("alpha"); // казвам да има име alpha
            var teamList = new List<ITeam>() { TeamMock.Object };  //  добавям го в един лист, защото ще проверя по-долу дали съществува

            // nie shte dobavim teama already kym nqkakv list

            var sut = new CreateTeamCommand(MockFactory.Object, MockDB.Object);

        }

        [TestMethod]
        public void CreateTeam_TeamAlreadyExists2()
        {
            //Act
            var factoryMock = new Mock<IFactory>();
            var dbMock = new Mock<IDataBase>();

            //Mock and Setup the team
            var teamMock = new Mock<ITeam>();
            teamMock.Setup(x => x.TeamName).Returns("alpha");
        //    var teamList = new Dictionary<ITeam> { teamMock.Object };

            //Mock and Setup the db
     //      dbMock.Setup(x => x.Teams).Returns(teamList);
         

      //      var sut = new CreateTeamCommand(MockFactory.Object, MockDB.Object);

        }



        [TestMethod]
        public void CreateTeam_InvalidNumberofParameters()
        {

        }
        [TestMethod]
        public void CreateTeam_PrintFormattedMessage()
        {

        }
    }
}
