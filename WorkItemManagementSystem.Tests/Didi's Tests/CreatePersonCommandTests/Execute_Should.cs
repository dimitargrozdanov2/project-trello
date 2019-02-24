using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Commands.Creating;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.CreatePersonCommandTeasts
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowException_WhenPassedInvalidParametersCount()
        {
            var expectedMessage = "Failed to parse CreatePerson command parameters.";
            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();

            var parameters = new List<string>() { "name", "name"};

            var sut = new CreatePersonCommand(factoryMock.Object, databaseMock.Object);

            var ex = Assert.ThrowsException<ArgumentException>(() => sut.Execute(parameters));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestMethod]
        public void AddCreatedPersonToPeople_WhenUserNameNotExist()
        {
            var people = new Dictionary<string, IPerson>();

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();

            var personMock = new Mock<IPerson>();
            var parameters = new List<string>() { "userName", "firstName", "lastName" };

            databaseMock.SetupGet(x => x.People).Returns(people);
            factoryMock.Setup(x => x.CreatePerson("userName", "firstName", "lastName")).Returns(personMock.Object);

            var sut = new CreatePersonCommand(factoryMock.Object, databaseMock.Object);
            sut.Execute(parameters);

            Assert.AreEqual(1, people.Count);
        }

        [TestMethod]
        public void ReturnMessage_WhenPersonIsCreated()
        {
            var firstName = "Diana";
            var lastName = "Krumova";
            var userName="didi89"; 

            var people = new Dictionary<string, IPerson>();
            var expectedMessage = $" {firstName} {lastName} with username: {userName} was created.";

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();

            var personMock = new Mock<IPerson>();

            var parameters = new List<string>() { userName,firstName,lastName,};

            personMock.SetupGet(p => p.UserName).Returns(userName);
            personMock.SetupGet(p => p.FirstName).Returns(firstName);
            personMock.SetupGet(p => p.LastName).Returns(lastName);

            databaseMock.SetupGet(x => x.People).Returns(people);
            factoryMock.Setup(x => x.CreatePerson(userName, firstName, lastName)).Returns(personMock.Object);

            var sut = new CreatePersonCommand(factoryMock.Object, databaseMock.Object);

            var message = sut.Execute(parameters);
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void ReturnMessage_WhenUserNameExist()
        {
            var userName = "didi89";
            var people = new Dictionary<string, IPerson>();

            var databaseMock = new Mock<IDataBase>();
            var factoryMock = new Mock<IFactory>();
            var personMock = new Mock<IPerson>();
            var parameters = new List<string>() { userName, "firstName", "lastName" };

            people.Add(userName, personMock.Object);

            databaseMock.SetupGet(x => x.People).Returns(people);
            factoryMock.Setup(x => x.CreatePerson(userName, "firstName", "lastName")).Returns(personMock.Object);

            var sut = new CreatePersonCommand(factoryMock.Object, databaseMock.Object);

            var ex = Assert.ThrowsException<ArgumentException>(() => sut.Execute(parameters));
            Assert.AreEqual($" {userName} already exists.", ex.Message);           
        }
    }
}
