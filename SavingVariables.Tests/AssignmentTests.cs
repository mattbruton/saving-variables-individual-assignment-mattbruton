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

        [TestMethod]
        public void AssignmentEnsureAssignmentNameChangedCorrectlyForShowSinglePattern()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesShowSinglePattern("show a");

            string expected_variable_name = "a";
            string actual_variable_name = test.AssignmentVariable;

            Assert.AreEqual(expected_variable_name, actual_variable_name);
        }

        [TestMethod]
        public void AssignmentEnsureMatchShowSingleWillFailIfInputDoesNotMatch()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesShowSinglePattern("showw a");

            Assert.IsFalse(test.IsInputValid);
        }

        [TestMethod]
        public void AssignmentEnsureAssignmentNameChangedCorrectlyForRemoveSinglePatternUsingRemove()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesRemoveSinglePattern("remove a");

            string expected_variable_name = "a";
            string actual_variable_name = test.AssignmentVariable;

            Assert.AreEqual(expected_variable_name, actual_variable_name);
        }

        [TestMethod]
        public void AssignmentEnsureAssignmentNameChangedCorrectlyForRemoveSinglePatternUsingDelete()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesRemoveSinglePattern("delete a");

            string expected_variable_name = "a";
            string actual_variable_name = test.AssignmentVariable;

            Assert.AreEqual(expected_variable_name, actual_variable_name);
        }

        [TestMethod]
        public void AssignmentEnsureAssignmentNameChangedCorrectlyForRemoveSinglePatternUsingClear()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesRemoveSinglePattern("clear a");

            string expected_variable_name = "a";
            string actual_variable_name = test.AssignmentVariable;

            Assert.AreEqual(expected_variable_name, actual_variable_name);
        }

        [TestMethod]
        public void AssignmentEnsureMatchRemoveSingleWillFailIfInputDoesNotMatch()
        {
            Assignment test = new Assignment();
            test.CheckIfInputMatchesShowSinglePattern("getout a");

            Assert.IsFalse(test.IsInputValid);
        }
    }
}
