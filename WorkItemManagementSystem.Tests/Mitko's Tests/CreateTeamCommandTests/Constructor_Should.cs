using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Creating;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Tests.Mitko_s_Tests.CreateTeamCommandTests
{

    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowNullException_WhenCreatingTeamWithFactoryNull()
        {
            var dbMock = new Mock<IDataBase>();
            Assert.ThrowsException<ArgumentNullException>
               (() => new CreateTeamCommand(null, dbMock.Object));
        }
        [TestMethod]
        public void ThrowNullException_WhenCreatingTeamWithDatabaseNull()
        {
            var factoryMock = new Mock<IFactory>();
            Assert.ThrowsException<ArgumentNullException>
               (() => new CreatePersonCommand(factoryMock.Object, null));
        }
    }
}
