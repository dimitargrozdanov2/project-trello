using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models;

namespace WorkItemManagementSystem.Tests.Mitko_s_Tests.Person_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowExceptionWhenInvalidUsername()
        {
            Assert.ThrowsException<ArgumentException>(() => new Person("gros", "Dimitar", "Grozdanov"));
        }

        [TestMethod]
        public void ThrowExceptionWhenInvalidFirstName()
        {
            Assert.ThrowsException<ArgumentException>(() => new Person("grozdeto", "DimitarGrozdanovGrozdanovGrozdanov", "Grozdanov"));

        }
        [TestMethod]
        public void ThrowExceptionWhenInvaliLastName()
        {
            Assert.ThrowsException<ArgumentException>(() => new Person("grozdeto", "null", "DimitarGrozdanovGrozdanovGrozdanov"));

        }
    }
}

