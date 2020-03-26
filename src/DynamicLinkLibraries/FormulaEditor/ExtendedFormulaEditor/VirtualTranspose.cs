using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Attributes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    [Empty()]
    public class VirtualTranspose : IObjectOperation, IOperationAcceptor, IOperationDetector
    {

        #region Fields
        public static readonly VirtualTranspose Singleton = new VirtualTranspose();
        #endregion

        #region Ctor
        private VirtualTranspose()
        {
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


        object IObjectOperation.this[object[] x]
        {
            get { return this; }
        }

        object IObjectOperation.ReturnType
        {
            get { return this; }
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
            if (!(s is SimpleSymbol))
            {
                return null;
            }
            SimpleSymbol ss = s as SimpleSymbol;
            if (ss.Italic | !ss.Bold)
            {
                return null;
            }
            if (ss.Symbol == '\u0442')
            {
                return this;
            }
            return null;
        }

        #endregion
    }
}
