using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SavingVariables.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackEnsureStackCanBeInstantiated()
        {
            Stack test = new Stack();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void StackEnsureStackCanSetCommandAsString()
        {
            Stack test = new Stack();
            test.SetLastExpOrCommand("show all");
            string actual_last_command = test.LastExpOrCommand;
            string expected_last_command = "show all";

            Assert.AreEqual(expected_last_command, actual_last_command);
        }

        [TestMethod]
        public void StackEnsureStackCanSetNewVariableAssignment()
        {
            Stack test = new Stack();
            test.SetLastExpOrCommand("a", 2);
            string actual_last_exp = test.LastExpOrCommand;
            string expected_last_exp = "'a' = '2'";

            Assert.AreEqual(expected_last_exp, actual_last_exp);
        }

        [TestMethod]
        public void StackEnsureStackCanHandleAnyCaseVariable()
        {
            Stack test = new Stack();
            test.SetLastExpOrCommand("A", 2);
            string actual_last_exp = test.LastExpOrCommand;
            string expected_last_exp = "'a' = '2'";

            Assert.AreEqual(expected_last_exp, actual_last_exp);
        }
    }
}
