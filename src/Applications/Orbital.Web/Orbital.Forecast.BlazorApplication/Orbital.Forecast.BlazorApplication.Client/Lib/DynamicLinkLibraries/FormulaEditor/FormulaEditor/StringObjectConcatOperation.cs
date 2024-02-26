using System;
using System.Collections.Generic;
using System.Text;


using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// String concatenation operation
    /// </summary>
    public class StringObjectConcatOperation : IObjectOperation, IBinaryAcceptor
    {

        /// <summary>
        /// Sinleton
        /// </summary>
        static public readonly StringObjectConcatOperation Object =
            new StringObjectConcatOperation();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected StringObjectConcatOperation()
        {

        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { "", "" };
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return "" + x[0] + x[1]; }
        }

        object IObjectOperation.ReturnType
        {
            get { return ""; }
        }

        #endregion

        #region IBinaryAcceptor Members

        /// <summary>
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (typeA == null | typeB == null | typeA is ArrayReturnType | typeB is ArrayReturnType)
            {
                return null;
            }
            if (typeA.Equals("") | typeB.Equals(""))
            {
                return this;
            }
            return null;
        }

        #endregion
    }
}
