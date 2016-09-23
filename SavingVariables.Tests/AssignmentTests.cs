using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

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
        public void AssignmentEnsureAssignmentPropertiesChangedCorrectlyForMethodThatModifiesBoth()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesAssignmentPattern("a=2");

            string expected_variable_name = "a";
            int expected_variable_value = 2;
            string actual_variable_name = test.AssignmentVariable;
            int actual_variable_value = test.AssignmentValue;

            Assert.AreEqual(expected_variable_name, actual_variable_name);
            Assert.AreEqual(expected_variable_value, actual_variable_value);
        }

        [TestMethod]
        public void AssignmentEnsureMatchAssignmentWillFailIfInputDoesNotMatch()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesAssignmentPattern("aa=2");

            Assert.IsFalse(test.IsInputValid);
        }
    }
}
