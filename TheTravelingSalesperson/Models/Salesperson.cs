using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    class Salesperson
    {
        #region FIELDS

        private string _lastName;
        private string _firstName;
        private int _accountNumber;
        private List<string> _citiesVisited;
        private string _currentCity;
        private WidgetItemStock _currentStock;
        private int _numberOfUnits;

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
            
        }



        #endregion

        #region PROPERTIES
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public List<string> CitiesVisited
        {
            get { return _citiesVisited; }
            set { _citiesVisited = value; }
        }

        public string CurrentCity
        {
            get { return _currentCity; }
            set { _currentCity = value; }
        }

        public WidgetItemStock CurrentStock
        {
            get {return _currentStock; }
            set { _currentStock = value; }
        }

        public void AddWidgets(int number)
        {
            _numberOfUnits += number;
        }
        

        #endregion

        #region METHODS

        #endregion

        #region CONSTRUCTORS

        public Salesperson()
        {
            _citiesVisited = new List<string>();
            _currentStock = new WidgetItemStock(); 
        }

        #endregion


    }
}
