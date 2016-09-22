using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface UI = new UserInterface();

            while (!UI.UserIsReadyToExit)
            {                            
                UI.PromptUser();
                UI.AcceptUserInputForAction(UI.user_choice);
            }
        }
    }
}   