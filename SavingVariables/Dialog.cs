using SavingVariables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    public class Dialog
    {
        public string Prompt()
        {
            return ">>";
        }
        public string CommandNotRecognized()
        {
            return string.Format("Command not recognized, try typing 'help' for a list of valid commands.");
        }
        public string SaveNewVariableResponse(string variable, string value)
        {
            return string.Format("  = '{0}' saved as '{1}'", variable, value);
        }
        public string ShowSingleVariableAndValue(Variable variable)
        {
            return string.Format("  = '{0}' is currently saved as '{1}'.", variable.Name, variable.Value);
        }

        public string ErrorNewVariableResponse(string variable)
        {
            return string.Format("  = Error! '{0}' is already defined!", variable);
        }
        public string ErrorVariableDoesNotExist(string variable)
        {
            return string.Format("  = Error! Cannot remove '{0}' as it has not been saved with a value yet!", variable);
        }
        public string EmptyDatabaseResponse()
        {
            return string.Format("  The database is empty, nothing to show.");
        }
        public string ListAllHeader()
        {
            return string.Format("Name -> Value");
        }

        public string ListAllItem(string variable, string value)
        {
            return string.Format("'{0}' -> '{1}'", variable, value);
        }

        public string ClearVariableResponse(string variable)
        {
            return string.Format("  = '{0}' is now free!", variable);
        }

        public string ClearAllResponse()
        {
            return string.Format("  = deleted all items from the database!");
        }

        public string ExitResponse()
        {
            return string.Format("Goodbye!");
        }

        public string HelpResponse()
        {
            return string.Format("List of Valid Commands: \n\nclear | delete | remove x - Removes saved variable from database. Replace 'x' with any variable of your choosing. \n\nclear | delete | remove all - Removes ALL saved variables from database. \n\nexit | quit - Exits the program. \n\nlastq - Shows last entered command or expression. \n\nlist all | show all - Shows all saved variables and their stored values.");
        }
    }
}
