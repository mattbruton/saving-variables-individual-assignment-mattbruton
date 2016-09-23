using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SavingVariables
{
     public class Assignment
    {
        public string AssignmentVariable;
        public int AssignmentValue;

        public bool IsInputValid;
        public bool ValueUnchanged = true;
        public bool IsVariableMarkedForRemoval;

        public Regex AssignmentPattern = new Regex(@"(\s*(?<Variable>[A-Za-z])\s*=\s*(?<Value>[-]?\d*)\s*)");
        public Regex RemoveSinglePattern = new Regex(@"(\s*(?<Command>(clear|delete|remove))\s*(?<Variable>[A-Za-z])\s*)");
        public Regex ShowSinglePattern = new Regex(@"(\s*(?<Command>(list|show))\s*(?<Variable>[A-Za-z])\s*)");
        
        public bool CheckIfInputMatchesAssignmentPattern(string input)
        {
            Match assignmentMatch = AssignmentPattern.Match(input);
            if (assignmentMatch.Success)
            {
                AssignUserInputToProperties(assignmentMatch);
                ValueUnchanged = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfInputMatchesShowSinglePattern(string input)
        {
            Match showSingleMatch = ShowSinglePattern.Match(input);
            if (showSingleMatch.Success)
            {
                AssignVariableNameToProperty(showSingleMatch);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfInputMatchesRemoveSinglePattern(string input)
        {
            Match removeSingleMatch = RemoveSinglePattern.Match(input);
            if (removeSingleMatch.Success)
            {
                IsVariableMarkedForRemoval = true;
                AssignVariableNameToProperty(removeSingleMatch);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckIfUserInputIsValid(string input)
        {
            if (CheckIfInputMatchesAssignmentPattern(input) || CheckIfInputMatchesShowSinglePattern(input) || CheckIfInputMatchesRemoveSinglePattern(input))
            {
                IsInputValid = true;
            }
            else
            {
                IsInputValid = false;
            }
        }

        public void AssignUserInputToProperties(Match match)
        {
            AssignmentVariable = match.Groups["Variable"].Value;
            AssignmentValue = Convert.ToInt32(match.Groups["Value"].Value);
        }

        public void AssignVariableNameToProperty(Match match)
        {
            AssignmentVariable = match.Groups["Variable"].Value;
        }
    }
}
