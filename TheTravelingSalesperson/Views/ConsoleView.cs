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

            ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
            _salesperson.LastName = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your account number: ");
            _salesperson.AccountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter the type of widget you will be selling: ");
            string userResponse = Console.ReadLine();
            _salesperson.CurrentStock.Type = (WidgetItemStock.WidgetType)Enum.Parse(typeof(WidgetItemStock.WidgetType), userResponse, true);
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter the number of widgets: ");
            _salesperson.AddWidgets(int.Parse(Console.ReadLine()));
            Console.WriteLine();

            //
            // TODO prompt the user to input all of the required account information
            //

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            //
            // TODO enable each application function separately and test
            //
            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                     "\t" + "2. Add Widgets" + Environment.NewLine +
                    "\t" + "3. Display Inventory" + Environment.NewLine +
                    "\t" + "4. Display Cities Visited and Current City" + Environment.NewLine +
                    "\t" + "5. Travel" + Environment.NewLine + 
                    "\t" + "6. Display Account Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '2':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        //
                        // TODO handle invalid menu responses from user
                        //
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo()
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("First Name: " + _salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + _salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account Number: " + _salesperson.AccountNumber);
             

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";
            

            ConsoleUtil.DisplayMessage("Next City of Travel: ");
            nextCity = Console.ReadLine();
            ConsoleUtil.DisplayReset();
            DisplayContinuePrompt();
            return nextCity;
        }

        public void DisplayCities()
        {
            ConsoleUtil.DisplayMessage($"Current City: {_salesperson.CurrentCity}");

            ConsoleUtil.DisplayMessage($"List of cities visited:");
            foreach (string city in _salesperson.CitiesVisited)
            {
                ConsoleUtil.DisplayMessage(city);
            }
            
            DisplayContinuePrompt();
            ConsoleUtil.DisplayReset();
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for using the application. Press any key to Exit.");

            Console.ReadKey();

        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayInventory()
        {
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"Widget type: {_salesperson.CurrentStock}");
            ConsoleUtil.DisplayMessage($"Widget type: {_salesperson.NumberOfUnits}");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the number of widget units to buy from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToBuy()
        {
            int numberOfUnitsToAdd = 0;

            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("How many do you want to buy?");
            numberOfUnitsToAdd = int.Parse(Console.ReadLine());

            return numberOfUnitsToAdd;
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
