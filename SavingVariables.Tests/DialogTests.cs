using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SavingVariables.Tests
{
    [TestClass]
    public class DialogTests
    {
        [TestMethod]
        public void DialogCanBeInstantiated()
        {
            Dialog test = new Dialog();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void DialogPromptIsExpectedFormat()
        {
            Dialog test = new Dialog();

            Assert.AreEqual(">>", test.Prompt());
        }

        [TestMethod]
        public void DialogSaveNewVariableResponseIsExpextedFormat()
        {
            Dialog test = new Dialog();
            string test_variable = "x";
            string test_value = 2.ToString();

            Assert.AreEqual("  = 'x' saved as '2'", test.SaveNewVariableResponse(test_variable, test_value));
        }
    }
}
