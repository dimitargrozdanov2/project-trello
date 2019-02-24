using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WorkItemManagementSystem.Commands.Creating;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.CreatePersonCommandTeasts
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowNullException_WhenFactoryIsNull()
        {
            var databaseMock = new Mock<IDataBase>();
            Assert.ThrowsException<ArgumentNullException>
               (() => new CreatePersonCommand(null,databaseMock.Object));
        }
        [TestMethod]
        public void ThrowNullException_WhenDatabaseIsNull()
        {
            var factoryMock = new Mock<IFactory>();
            Assert.ThrowsException<ArgumentNullException>
               (() => new CreatePersonCommand(factoryMock.Object,null));
        }
    }
}
