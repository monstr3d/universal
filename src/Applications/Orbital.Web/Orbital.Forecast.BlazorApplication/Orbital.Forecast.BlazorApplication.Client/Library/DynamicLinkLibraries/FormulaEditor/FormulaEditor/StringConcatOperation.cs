using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// String concatenation operation
    /// </summary>
    public class StringConcatOperation : IObjectOperation, IBinaryAcceptor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly StringConcatOperation Object =
            new StringConcatOperation();

        /// <summary>
        /// Constructor
        /// </summary>
        protected StringConcatOperation()
        {

        }

        private static readonly object[] types = new object[] { "", "" };


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

        object IObjectOperation.this[object[] x]
        {
            get
            {
                string s = "" + x[0] + x[1];
                return s;
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return ""; }
        }

        #endregion


        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            if (typeA.Equals("") & typeB.Equals(""))
            {
                return this;
            }
            return null;
        }

        #endregion
    }
}