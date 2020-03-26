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
    /// Conversion of time to date time
    /// </summary>
    public class TimeToDoubleOperation : IObjectOperation, IPowered, IOperationAcceptor, IOperationDetector
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly TimeToDoubleOperation Object = new TimeToDoubleOperation();

        static private readonly object[] types = new object[] { new DateTime() };

        const Double a = 0;


        #endregion

        #region Ctor

        private TimeToDoubleOperation()
        {
        }

        #endregion

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get { return types; }
        }

        object IObjectOperation.this[object[] x]
        {
            get
            {
                DateTime dt = (DateTime)x[0];
                return dt.DateTimeToDay();
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return a; }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            if (type.Equals(BaseTypes.FixedTypes.DateTimeType))
            {
                return new TimeToDoubleOperation();
            }
            return null;
        }

        #endregion

        #region IOperationDetector Members

        IOperationAcceptor IOperationDetector.Detect(MathSymbol s)
        {
            if (s.SymbolType == (byte)FormulaConstants.Unary & s.Symbol != '\u2211' & !(s.Symbol + "").Equals("'"))
            {
                if (s.Symbol == 'o')
                {
                    return new TimeToDoubleOperation();
                }
            }
            return null;
        }

        #endregion
    }
}
