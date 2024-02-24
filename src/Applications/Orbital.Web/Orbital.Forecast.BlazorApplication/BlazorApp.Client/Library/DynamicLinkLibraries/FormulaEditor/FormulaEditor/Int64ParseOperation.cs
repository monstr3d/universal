using System;
using System.Collections.Generic;
using System.Text;


using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// Parse Int32 operation
    /// </summary>
    public class Int32ParseOperation : IObjectOperation, IPowered, IOperationAcceptor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly Int32ParseOperation Object = new Int32ParseOperation();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected Int32ParseOperation()
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
                return new object[] { "" };
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return Int32.Parse(x[0] + ""); }
        }

        object IObjectOperation.ReturnType
        {
            get { return BaseTypes.StaticExtensionBaseTypes.Int32Type; }
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
