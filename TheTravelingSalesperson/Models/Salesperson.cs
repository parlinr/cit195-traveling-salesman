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

        #endregion

        #region METHODS

        #endregion

        #region CONSTRUCTORS

        public Salesperson()
        {

        }

        #endregion


    }
}
