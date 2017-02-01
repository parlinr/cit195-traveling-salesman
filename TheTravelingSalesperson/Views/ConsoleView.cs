using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    class ConsoleView
    {
        #region FIELDS
        private Salesperson _salesperson;


        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("- add welcome message -");
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details.");
            sb.AppendFormat("Good luck with your sales.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        public void DisplaySetupAccount()
        {
            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your first name: ");
            _salesperson.FirstName = Console.ReadLine();
            Console.WriteLine();

            //
            // TODO prompt the user to input all of the required account information
            //

            DisplayContinuePrompt();
        }

        #endregion

        #region CONSTRUCTORS

        public ConsoleView()
        {

        }

        public ConsoleView(Salesperson salesperson)
        {
            _salesperson = salesperson;
        }

        #endregion
    }
}
