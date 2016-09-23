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

        public Regex AssignmentPattern = new Regex(@"(\s*(?<Variable>[A-Za-z])\s*=\s*(?<Value>[-]?\d*)\s*)");
        //public Regex RemoveSinglePattern = new Regex(@"(\s*(?<Command>(clear)|(delete)|(remove))\s(?<Variable>[A-Z])\s*)");
        //public Regex ShowSinglePttern = new Regex(@"(?<Command>(list)|(show))\s(?<Variable>[A-Z])\s*)");
        
        public bool CheckIfInputMatchesAssignmentPattern(string input)
        {
            Match assignmentMatch = AssignmentPattern.Match(input);
            if (assignmentMatch.Success)
            {
                AssignUserInputToProperties(assignmentMatch);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckIfUserInputIsValid(string input)
        {
            if (CheckIfInputMatchesAssignmentPattern(input))
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
    }
}
