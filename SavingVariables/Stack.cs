using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    public class Stack
    {
        public string LastExpOrCommand;

        // Method to handle commands.
        public void SetLastExpOrCommand(string input)
        {
            LastExpOrCommand = input;
        }
        // Overloaded method to handle new variable assignment.
        public void SetLastExpOrCommand(string name, int value)
        {
            LastExpOrCommand = string.Format("'{0}' = '{1}'", name.ToLower(), value);
        }
    }
}
