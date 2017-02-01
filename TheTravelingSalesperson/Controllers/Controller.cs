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
            //show welcome screen
            _consoleView.DisplayWelcomeScreen();

            //setup account
            _consoleView.DisplaySetupAccount();
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
