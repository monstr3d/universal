using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// String operation acceptor
    /// </summary>
    public class StringOperationAcceptor : IObjectOperation, IOperationAcceptor
    {

        #region Fields

        private static readonly string typeOp = "";

        private string str;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="str">String operation result</param>
        public StringOperationAcceptor(string str)
        {
            if (str != null)
            {
                this.str = str + "";
            }
        }

        #endregion

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return str;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return typeOp;
            }
        }

        #endregion

        #region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            if (typeOp.Equals(type))
            {
                return this;
            }
            return this;
        }

        #endregion
    }
}
