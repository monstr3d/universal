using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Parsing of string to double opreation
    /// </summary>
    public class DoubleParseOperation : IObjectOperation, IPowered, IOperationAcceptor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly DoubleParseOperation Object = new DoubleParseOperation();

        static private readonly object[] types = new object[] { "" };


        /// <summary>
        /// Default constructor
        /// </summary>
        protected DoubleParseOperation()
        {
        }

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
                return Double.Parse(x[0] + "");
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return BaseTypes.StaticExtensionBaseTypes.DoubleType; }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            if (type.Equals(""))
            {
                return this;
            }
            return null;
        }

        #endregion
    }
}
