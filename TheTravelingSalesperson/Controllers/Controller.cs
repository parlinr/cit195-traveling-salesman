using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    class Controller
    {
        #region FIELDS
        private Salesperson _salesperson;
        private ConsoleView _consoleView;

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS
        /// <summary>
        /// Application control method
        /// </summary>
        private void ManageApplicationLoop()
        {
            bool _usingApplication = true;

            MenuOption userMenuChoice;
            //show welcome screen
            _consoleView.DisplayWelcomeScreen();

            //setup account
            _consoleView.DisplaySetupAccount();

            //main menu
            while(_usingApplication)
            {
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                switch (userMenuChoice)
                {
                    /*
                    case MenuOption.None:
                        break;
                    */
                    case MenuOption.Travel:
                        string nextCity = _consoleView.DisplayGetNextCity();
                        if (!_salesperson.CitiesVisited.Contains(nextCity))
                        {
                            _salesperson.CitiesVisited.Add(nextCity);
                        }
                        _salesperson.CurrentCity = nextCity;
                        break;
                    case MenuOption.Buy:
                        _salesperson.AddWidgets(_consoleView.DisplayGetNumberOfUnitsToBuy());
                        break;
                    case MenuOption.Sell:
                        break;
                    case MenuOption.DisplayInventory:
                        _consoleView.DisplayInventory();
                        break;
                    case MenuOption.DisplayCities:
                        _consoleView.DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        _consoleView.DisplayAccountInfo();
                        break;
                    case MenuOption.Exit:
                        _consoleView.DisplayExitPrompt();
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            Environment.Exit(42);
        }


        #endregion

        #region CONSTRUCTORS
        public Controller()
        {
            //instantiate salesperson
            _salesperson = new Salesperson();

            //instantiate the console view
            _consoleView = new ConsoleView(_salesperson);

            //call application loop manager method
            ManageApplicationLoop();
        }

        
        #endregion

    }
}
