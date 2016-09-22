using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    public class UserInterface
    {
        Dialog dialog = new Dialog();
        Assignment assignment = new Assignment();
        Stack stack = new Stack();

        public string user_choice;
        public void PromptUser()
        {
            Console.Write(dialog.Prompt());
            user_choice = Console.ReadLine();
        }
        public void AcceptUserInputForAction(string input)
        {
            stack.SetLastExpOrCommand(input);
            switch (input.ToLower())
            {
                case "remove all":
                case "clear all":
                case "delete all":
                    {
                        break;
                    }
                case "exit":
                case "quit":
                    {
                        Console.WriteLine(dialog.ExitResponse());
                        Console.ReadKey();
                        break;
                    }
                case "lastp":
                    {
                        Console.WriteLine(stack.LastExpOrCommand);
                        break;
                    }
                case "show all":
                case "list all":
                    {
                        break;
                    }
                default:
                    {
                        assignment.CheckIfUserInputIsValid(input);
                        if (assignment.IsInputValid)
                        {
                            Console.WriteLine(dialog.SaveNewVariableResponse(assignment.AssignmentVariable, assignment.AssignmentValue.ToString()));
                        }
                        break;
                    }
            }
        }

    }
}
