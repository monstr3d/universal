using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{

    /// <summary>
    /// This operation converts double value to time
    /// </summary>
    public class TimeOperation : IObjectOperation, IOperationAcceptor
    {
        #region Fields
        
        private DateTimeSymbol symbol = new DateTimeSymbol();

        private static readonly Double a = 0;

        #endregion

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { (double)0 };
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                double a = (double)x[0];
                return a.DayToDateTime();
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return BaseTypes.FixedTypes.DateTimeType; }
        }

         #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            if (type.Equals(a))
            {
                return this;
            }
            return null;
        }

        #endregion
    }
}
