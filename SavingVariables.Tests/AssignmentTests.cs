using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SavingVariables.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void AssignmentEnsureAssignmentCanBeInstantiated()
        {
            Assignment test = new Assignment();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void AssignmentEnsure()
        {

        }
    }
}
