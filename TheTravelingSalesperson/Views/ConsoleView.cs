﻿using System;
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

            ConsoleUtil.HeaderText = "Welcome to your Control Panel";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Welcome to your Control Panel");
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details. ");
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
            //TODO Validate initial input
            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your first name:  ");
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
            _salesperson.CurrentStock.AddUnits(int.Parse(Console.ReadLine()));
            Console.WriteLine();

            
            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            
            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Main Menu";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Buy Widgets" + Environment.NewLine +
                     "\t" + "2. Sell Widgets" + Environment.NewLine +
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
                    case '1':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Sell;
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
            ConsoleUtil.HeaderText = "Travel";
            ConsoleUtil.DisplayReset();

            string nextCity = "";
            

            ConsoleUtil.DisplayPromptMessage("Next City of Travel: ");
            nextCity = Console.ReadLine();
            DisplayContinuePrompt();
            return nextCity;
        }

        public void DisplayCities()
        {
            ConsoleUtil.HeaderText = "Current City and Cities Visited";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Current City: {_salesperson.CurrentCity}");
            Console.WriteLine();

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
            ConsoleUtil.HeaderText = "Exit";
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
            ConsoleUtil.HeaderText = "Inventory";
            ConsoleUtil.DisplayReset();
            

            ConsoleUtil.DisplayMessage($"Widget type: {Enum.GetName(typeof(WidgetItemStock.WidgetType), _salesperson.CurrentStock.Type)}");


            ConsoleUtil.DisplayMessage($"Number of units: {_salesperson.CurrentStock.ProductUnits}");
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

            
            try
            {
                ConsoleUtil.DisplayPromptMessage("How many do you want to buy? ");
                numberOfUnitsToAdd = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                ConsoleUtil.DisplayMessage("You did not enter an integer.");
            }
            catch (OverflowException)
            {
                ConsoleUtil.DisplayMessage("Your integer was too large.");
            }
            catch (Exception)
            {
                ConsoleUtil.DisplayMessage("An error occurred.");
            }


            ConsoleUtil.DisplayPromptMessage($"{numberOfUnitsToAdd} units successfully purchased.");
            DisplayContinuePrompt();

            return numberOfUnitsToAdd;
        }

        /// <summary>
        /// get the number of widget units to sell from the user
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNumberOfUnitsToSell()
        {
            int numberOfUnitsToSell = 0;

            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            
            try
            {
                ConsoleUtil.DisplayPromptMessage("How many do you want to sell? ");
                numberOfUnitsToSell = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                ConsoleUtil.DisplayMessage("You did not enter an integer.");
            }
            catch (OverflowException)
            {
                ConsoleUtil.DisplayMessage("Your integer was too large.");
            }
            catch (Exception)
            {
                ConsoleUtil.DisplayMessage("An error occurred.");
            }

            if (_salesperson.CurrentStock.ProductUnits - numberOfUnitsToSell < 0)
            {
                ConsoleUtil.DisplayMessage("You cannot sell more units than you have in inventory.");
                numberOfUnitsToSell = 0;
                DisplayContinuePrompt();

            }
            else
            {
                ConsoleUtil.DisplayPromptMessage($"{numberOfUnitsToSell} units successfully sold.");
                DisplayContinuePrompt();
            }

            

            return numberOfUnitsToSell;
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
