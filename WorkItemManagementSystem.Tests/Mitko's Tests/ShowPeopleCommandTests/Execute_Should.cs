using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Listing;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Tests.Mitko_s_Tests.ShowPeopleCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShowAllPeople()
        {
            var dbMock = new Mock<IDataBase>();
            var people = new Dictionary<string, IPerson>();
            var peshoMock = new Mock<IPerson>();
            var ivanMock = new Mock<IPerson>();
            people.Add("grozdeto", peshoMock.Object);
            people.Add("didi89", ivanMock.Object);
            dbMock.Setup(x => x.People).Returns(people);
            peshoMock.Setup(x => x.FirstName).Returns("Dimitar");
            ivanMock.Setup(x => x.FirstName).Returns("Diana");
            var sut = new ShowPeopleCommand(dbMock.Object);
            var message = sut.Execute(new List<string>());

            StringAssert.Contains(message, "* Dimitar");
            StringAssert.Contains(message, "* Diana");
        }
        [TestMethod]
        public void Return_Message_WhenNoPeopleareRegistered()
        {
            var dbMock = new Mock<IDataBase>();
            var people = new Dictionary<string, IPerson>();
            dbMock.Setup(x => x.People).Returns(people);
            var sut = new ShowPeopleCommand(dbMock.Object);
            var message = sut.Execute(new List<string>());
            Assert.AreEqual(" There are no registered users.", message);
        }
    }
}