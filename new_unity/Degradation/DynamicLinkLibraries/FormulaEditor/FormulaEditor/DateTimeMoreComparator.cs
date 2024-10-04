using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
    internal class DateTimeMoreComparator : IObjectOperation, IBinaryAcceptor
    {
        static private readonly Boolean b = false;

        static public readonly DateTimeMoreComparator Object =
            new DateTimeMoreComparator();
        static public object[] types = new object[] { new DateTime(), new DateTime() };

        protected DateTimeMoreComparator()
        {
        }
        
        #region IObjectOperation Members

         /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        public virtual object this[object[] x]
        {
            get
            {
                DateTime dt0 = (DateTime)x[0];
                DateTime dt1 = (DateTime)x[1];
                return dt0 > dt1;
            }
        }

        public object ReturnType
        {
            get { return b; }
        }

        #endregion


        #region IBinaryAcceptor Members

        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (typeA.Equals(BaseTypes.FixedTypes.DateTimeType) & typeB.Equals(BaseTypes.FixedTypes.DateTimeType))
            {
                return this;
            }
            return null;
        }

        #endregion
}
}