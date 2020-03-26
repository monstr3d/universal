using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Attributes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Symbol of date time
    /// </summary>
    [DefaultValue("new DateTime()")]
    public class DateTimeSymbol : SimpleSymbol, IObjectOperation, IOperationAcceptor, IOperationDetector
    {
        /// <summary>
        /// The Date time
        /// </summary>
        protected DateTime dt;

        /// <summary>
        /// Singleton
        /// </summary>
        //static public readonly DateTimeSymbol Object = new DateTimeSymbol();

        /// <summary>
        /// Default constructor
        /// </summary>
        public DateTimeSymbol()
            : base('d', 0, false, true, "Date Time")
        {
        }

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            DateTimeSymbol sym = new DateTimeSymbol();
            sym.dt = dt;
            return sym;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public DateTimeSymbol(DateTimeSymbol s)
            : base(s)
        {
            dt = s.dt;
        }

        /// <summary>
        /// Overriden
        /// </summary>
        /// <returns>String representation of object</returns>
        public override string ToString()
        {
            string ms = dt.Millisecond + "";
            string ss = "";
            for (int i = 0; i < 3 - ms.Length; i++)
            {
                ss += "0";
            }
            return dt.ToLongDateString() + " " + dt.ToLongTimeString() + MathSymbol.DecimalSep + ss + ms;
        }

        /// <summary>
        /// Date time
        /// </summary>
        public DateTime DateTime
        {
            set
            {
                dt = value;
            }
        }


        #region IObjectOperation Members

        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return dt; }
        }

        object IObjectOperation.ReturnType
        {
            get { return BaseTypes.FixedTypes.DateTimeType; }
        }

         #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion

        #region IOperationDetector Members

        IOperationAcceptor IOperationDetector.Detect(MathSymbol s)
        {
            if (s is DateTimeSymbol)
            {
                DateTimeSymbol dt = s as DateTimeSymbol;
                return dt;
            }
            return null;
        }

        #endregion

    }
}
