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

        private VariableRepository variableRepo = new VariableRepository(new VariableContext());
        
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
                variableRepo.RemoveVariable(assignment.AssignmentVariable);
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
            if (variableRepo.FindVariableByName(testVar.Name) != null)
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
                Console.WriteLine(dialog.ShowSingleVariableAndValue(variableRepo.FindVariableByName(assignment.AssignmentVariable)));
            }
            else
            {
                AttemptToRemoveVariableWithUserInput();
            }
        }
        private void ShowProperResponseToListAllQuery()
        {
            List<Variable> all_var = variableRepo.GetVariables();
            if (all_var.Count == 0)
            {
                Console.WriteLine(dialog.EmptyDatabaseResponse());
            }
            else
            {
                Console.WriteLine(dialog.ListAllHeader());
                foreach (var variable in all_var)
                {
                    Console.WriteLine(dialog.ListAllItem(variable.Name, variable.Value.ToString()));
                }
            }
        }
        private void AddAndRespondToNewVariableAssignment()
        {
            if (!DoesVariableAlreadyExistInDb())
            {
                variableRepo.AddVariable(assignment.AssignmentVariable, assignment.AssignmentValue);
                Console.WriteLine(dialog.SaveNewVariableResponse(assignment.AssignmentVariable, assignment.AssignmentValue.ToString()));
            }
            else
            {
                Console.WriteLine(dialog.ErrorNewVariableResponse(assignment.AssignmentVariable));
            }
        }
        public void AcceptUserInputForAction(string input)
        {
            if (input != "lastq")
            {
                stack.SetLastExpOrCommand(input);
            }
            switch (input.ToLower())
            {
                case "remove all":
                case "clear all":
                case "delete all":
                    {
                        variableRepo.RemoveAllVariables();
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
                case "show all":
                case "list all":
                    {
                        ShowProperResponseToListAllQuery();
                        break;
                    }
                case "lastq":
                    {
                        Console.WriteLine(stack.LastExpOrCommand);
                        break;
                    }
                case "help":
                    {
                        Console.WriteLine(dialog.HelpResponse());
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
