using System;
using SavingVariables.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.Models;

namespace SavingVariables
{
    public class UserInterface
    {
        Dialog dialog = new Dialog();
        Assignment assignment = new Assignment();
        Stack stack = new Stack();

        private VariableRepository variableDb = new VariableRepository(new VariableContext());
        
        public bool UserIsReadyToExit;
        public string user_choice;

        public void PromptUser()
        {
            Console.Write(dialog.Prompt());
            user_choice = Console.ReadLine();
        }
        private void AttemptToRemoveVariableWithUserInput()
        {
            try
            {
                variableDb.RemoveVariable(assignment.AssignmentVariable);
                Console.WriteLine(dialog.ClearVariableResponse(assignment.AssignmentVariable));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(dialog.ErrorVariableDoesNotExist(assignment.AssignmentVariable));
            }
        }
        private void ResetAssignmentBooleans()
        {
            assignment.IsVariableMarkedForRemoval = false;
            assignment.ValueUnchanged = true;
        }
        private bool DoesVariableAlreadyExistInDb()
        {
            Variable testVar = new Variable { Name = assignment.AssignmentVariable, Value = 0 };
            if (variableDb.FindVariableByName(testVar.Name) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DetermineIfUserWantsToShowOrRemoveItem()
        {
            if (!assignment.IsVariableMarkedForRemoval)
            {
                Console.WriteLine(dialog.ShowSingleVariableAndValue(variableDb.FindVariableByName(assignment.AssignmentVariable)));
            }
            else
            {
                AttemptToRemoveVariableWithUserInput();
            }
        }
        private void AddAndRespondToNewVariableAssignment()
        {
           

                if (!DoesVariableAlreadyExistInDb())
                {
                    variableDb.AddVariable(assignment.AssignmentVariable, assignment.AssignmentValue);
                    Console.WriteLine(dialog.SaveNewVariableResponse(assignment.AssignmentVariable, assignment.AssignmentValue.ToString()));
                }
                else
                {
                    Console.WriteLine(dialog.ErrorNewVariableResponse(assignment.AssignmentVariable));
                }
            
        }
        public void AcceptUserInputForAction(string input)
        {
            if (input != "lastp")
            {
                stack.SetLastExpOrCommand(input);
            }
            switch (input.ToLower())
            {
                case "remove all":
                case "clear all":
                case "delete all":
                    {
                        variableDb.RemoveAllVariables();
                        Console.WriteLine(dialog.ClearAllResponse());
                        break;
                    }
                case "exit":
                case "quit":
                    {
                        UserIsReadyToExit = true;
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
                        Console.WriteLine(dialog.ListAllHeader());
                        List<Variable> all_var = variableDb.GetVariables();
                        foreach (var variable in all_var)
                        {
                            Console.WriteLine(dialog.ListAllItem(variable.Name, variable.Value.ToString()));
                        }
                        break;
                    }
                default:
                    {
                        assignment.CheckIfUserInputIsValid(input);

                        if (assignment.IsInputValid)
                        {
                            if (!assignment.ValueUnchanged)
                            {
                                AddAndRespondToNewVariableAssignment();
                            }
                            else
                            {
                                DetermineIfUserWantsToShowOrRemoveItem();
                            }
                        }
                        else
                        {
                            Console.WriteLine(dialog.CommandNotRecognized());
                        }
                        ResetAssignmentBooleans();
                        break;
                    }
            }
        }

    }
}
