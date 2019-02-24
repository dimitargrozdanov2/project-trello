using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Commands.Adding;

namespace WorkItemManagementSystem.Tests.Didi_s_Tests.AddMemberCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowNullException_WhenDatabaseIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AddMemberCommand(null));
        }
    }
}
