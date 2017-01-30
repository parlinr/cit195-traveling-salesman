using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson
{
    public class Salesperson
    {
        #region FIELDS

        private string _firstName;

        #endregion
        
        #region PROPERTIES

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Salesperson()
        {

        }

        public Salesperson(string firstName)
        {
            _firstName = firstName;
        }

        #endregion


        #region METHODS



        #endregion
    }
}
