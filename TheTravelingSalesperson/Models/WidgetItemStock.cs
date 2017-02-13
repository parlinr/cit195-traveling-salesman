using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    public class WidgetItemStock
    {
        #region ENUMERABLES

        public enum WidgetType
        {
            None,
            Fuzzy,
            Spotted,
            Striped
        }

        #endregion
        
        #region FIELDS

        private WidgetType _type;
        private int _productUnits;

        #endregion

        
        #region PROPERTIES

        public WidgetType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int ProductUnits
        {
            get { return _productUnits; }
        }

        #endregion

        #region METHODS
        /// <summary>
        /// add widgets to the inventory
        /// </summary>
        /// <param name="unitsToAdd">number of units to add</param>
        public void AddUnits(int unitsToAdd)
        {
            _productUnits += unitsToAdd;
        }

        
        /// <summary>
        /// subtract widgets from the inventory
        /// </summary>
        /// <param name="unitsToSubtract">number of units to subtract</param>
        public void SubtractUnits(int unitsToSubtract)
        {
            _productUnits -= unitsToSubtract;
        }

        #endregion

        #region CONSTRUCTORS

        public WidgetItemStock()
        {
            _type = WidgetType.None;
            _productUnits = 0;
        }

        public WidgetItemStock(WidgetType type, int numberOfUnits)
        {
            _type = type;
            _productUnits = numberOfUnits;
        }

        #endregion
    }






}
