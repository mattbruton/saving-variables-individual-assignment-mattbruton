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

            string expected_string = ">>";

            Assert.AreEqual(expected_string, test.Prompt());
        }

        [TestMethod]
        public void DialogSaveNewVariableResponseIsExpextedFormat()
        {
            Dialog test = new Dialog();

            string test_variable = "x";
            string test_value = 2.ToString();
            string expected_string = "  = 'x' saved as '2'";

            Assert.AreEqual(expected_string, test.SaveNewVariableResponse(test_variable, test_value));
        }

        [TestMethod]
        public void DialogErrorResponseIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string test_variable = "x";
            string expected_string = "  = Error! 'x' is already defined!";

            Assert.AreEqual(expected_string, test.ErrorNewVariableResponse(test_variable));
        }

        [TestMethod]
        public void DialogListAllHeaderIsExpectedtFormat()
        {
            Dialog test = new Dialog();

            string expected_string = "Name -> Value";

            Assert.AreEqual(expected_string, test.ListAllHeader());
        }

        [TestMethod]
        public void DialogListAllItemIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string test_variable = "x";
            string test_value = 2.ToString();
            string expected_string = "'x' -> '2'";

            Assert.AreEqual(expected_string, test.ListAllItem(test_variable, test_value));
        }

        [TestMethod]
        public void DialogClearAllResponseIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string expected_string = "  = deleted all items from the database!";

            Assert.AreEqual(expected_string, test.ClearAllResponse());
        }

        [TestMethod]
        public void DialogClearVariableResponseIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string test_variable = "x";
            string expected_string = "  = 'x' is now free!";

            Assert.AreEqual(expected_string, test.ClearVariableResponse(test_variable));
        }

        [TestMethod]
        public void DialogExitResponseIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string expected_string = "Goodbye!";

            Assert.AreEqual(expected_string, test.ExitResponse());
        }

        [TestMethod]
        public void DialogHelpResponseIsExpectedFormat()
        {
            Dialog test = new Dialog();

            string expected_string = "List of Valid Commands: \n\nclear | delete | remove x - Removes saved variable from database. Replace 'x' with any variable of your choosing. \n\nclear | delete | remove all - Removes ALL saved variables from database. \n\nexit | quit - Exits the program. \n\nlastq - Shows last entered command or expression. \n\nlist all | show all - Shows all saved variables and their stored values.";

            Assert.AreEqual(expected_string, test.HelpResponse());
        }
    }
}
