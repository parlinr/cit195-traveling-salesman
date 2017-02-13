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
        /// setup the new salesperson object with the initial data and validate the data
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

            ConsoleUtil.DisplayPromptMessage("Enter your first name:  ");
            _salesperson.FirstName = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
            _salesperson.LastName = Console.ReadLine();
            Console.WriteLine();

            //validating account number
            bool validAccountNumber = false;
            
            while (!validAccountNumber)
            {
                //indicates whether or not an exception was thrown
                string exceptionMessage = "";

                try
                {
                    ConsoleUtil.DisplayPromptMessage("Enter your account number: ");
                    _salesperson.AccountNumber = int.Parse(Console.ReadLine());
                    
                }
                catch (FormatException e)
                {
                    ConsoleUtil.DisplayMessage("You did not enter an integer.");
                    exceptionMessage = e.Message;
                }
                catch (OverflowException e)
                {
                    ConsoleUtil.DisplayMessage("Your number was too large.");
                    exceptionMessage = e.Message;
                }
                catch (Exception e)
                {
                    ConsoleUtil.DisplayMessage("An error occurred.");
                    exceptionMessage = e.Message;
                }
                finally
                {
                    Console.WriteLine();
                }
                if (exceptionMessage == "")
                {
                    validAccountNumber = true;
                }
            }


            //validating widget type
            bool validWidgetType = false;
            while (!validWidgetType)
            {
                //indicates whether or not an exception was thrown
                string exceptionMessage = "";

                try
                {
                    ConsoleUtil.DisplayPromptMessage("Enter the type of widget you will be selling: ");
                    string userResponse = Console.ReadLine();
                    _salesperson.CurrentStock.Type = (WidgetItemStock.WidgetType)Enum.Parse(typeof(WidgetItemStock.WidgetType), userResponse, true);
                    int widgetAsInt = (int)_salesperson.CurrentStock.Type;
                    if (widgetAsInt < 1 || widgetAsInt > 3)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                catch (ArgumentException e)
                {
                    ConsoleUtil.DisplayMessage("You did not enter a valid widget type.");
                    exceptionMessage = e.Message;
                }
                catch (IndexOutOfRangeException)
                {
                    ConsoleUtil.DisplayMessage("You did not enter a valid widget type.");
                    exceptionMessage = "Not within the enum or user selected type none.";
                }
                catch (Exception e)
                {
                    ConsoleUtil.DisplayMessage("An error occurred.");
                    exceptionMessage = e.Message;
                }
                finally
                {
                    Console.WriteLine();
                }

                if (exceptionMessage == "")
                {
                    validWidgetType = true;
                }
            }

            //validating number of widgets
            bool validWidgetCount = false;

            while (!validWidgetCount)
            {
                //indicates whether or not an exception was thrown
                string exceptionMessage = "";

                try
                {
                    ConsoleUtil.DisplayPromptMessage("Enter the number of widgets: ");
                    _salesperson.CurrentStock.AddUnits(int.Parse(Console.ReadLine()));

                }
                catch (FormatException e)
                {
                    ConsoleUtil.DisplayMessage("You did not enter an integer.");
                    exceptionMessage = e.Message;
                }
                catch (OverflowException e)
                {
                    ConsoleUtil.DisplayMessage("Your number was too large.");
                    exceptionMessage = e.Message;
                }
                catch (Exception e)
                {
                    ConsoleUtil.DisplayMessage("An error occurred.");
                    exceptionMessage = e.Message;
                }
                finally
                {
                    Console.WriteLine();
                }
                if (exceptionMessage == "")
                {
                    validWidgetCount = true;
                }
            }
            
            
            
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
                    "\t" + "7. Update Account Info" + Environment.NewLine +
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
                    case '7':
                        userMenuChoice = MenuOption.UpdateAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage("You did not enter a valid input.");
                        DisplayContinuePrompt();
                        ConsoleUtil.DisplayReset();
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

        public void DisplayUpdateAccountInfo()
        {
            
            bool updatingAccountInfo = true;

            while (updatingAccountInfo)
            {
                ConsoleUtil.HeaderText = "Update Account Info";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                ConsoleUtil.DisplayMessage("Select the attribute you wish to update:");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. First Name" + Environment.NewLine +
                     "\t" + "2. Last Name" + Environment.NewLine +
                    "\t" + "3. Account Number" + Environment.NewLine +
                    "\t" + "4. Widget Type" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                ConsoleUtil.DisplayReset();
                switch (userResponse.KeyChar)
                {
                    case '1':
                        ConsoleUtil.DisplayPromptMessage("Enter the new first name: ");
                        _salesperson.FirstName = Console.ReadLine();
                        DisplayContinuePrompt();
                        break;
                    case '2':
                        ConsoleUtil.DisplayPromptMessage("Enter the new last name: ");
                        _salesperson.LastName = Console.ReadLine();
                        DisplayContinuePrompt();
                        break;
                    case '3':
                        ConsoleUtil.DisplayPromptMessage("Enter the new account number: ");
                        try
                        {
                            _salesperson.AccountNumber = int.Parse(Console.ReadLine());
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
                        DisplayContinuePrompt();
                        break;
                    case '4':
                        ConsoleUtil.DisplayPromptMessage("Enter the new widget type: ");
                        try
                        {
                            _salesperson.CurrentStock.Type = (WidgetItemStock.WidgetType)Enum.Parse(typeof(WidgetItemStock.WidgetType), Console.ReadLine(), true);
                            int widgetAsInt = (int)_salesperson.CurrentStock.Type;
                            if (widgetAsInt < 1 || widgetAsInt > 3)
                            {
                                throw new IndexOutOfRangeException();
                            }
                        }
                        catch (ArgumentException e)
                        {
                            ConsoleUtil.DisplayMessage("You did not enter a valid widget type.");
                            
                        }
                        //using one of the predefined exception types for when the user enters a number, say '0' or '4' that does not correspond to a widget type
                        catch (IndexOutOfRangeException)
                        {
                            ConsoleUtil.DisplayMessage("You did not enter a valid widget type.");
                            
                        }
                        catch (Exception e)
                        {
                            ConsoleUtil.DisplayMessage("An error occurred.");
                            
                        }
                        DisplayContinuePrompt();
                        break;
                    case 'E':
                    case 'e':
                        updatingAccountInfo = false;
                        DisplayContinuePrompt();
                        break;
                    default:
                        ConsoleUtil.DisplayMessage("You did not enter a valid input.");
                        DisplayContinuePrompt();
                        break;

                }
            }


            
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
