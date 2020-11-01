using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Operation of string equality
    /// </summary>
    public class StringEqualityOperation : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {

        static private readonly Boolean b = false;

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly StringEqualityOperation Object = new StringEqualityOperation();

        static private readonly object[] types = new object[] { "", "" };


        /// <summary>
        /// Default constructor
        /// </summary>
        protected StringEqualityOperation()
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
            get { return ("" + x[0]).Equals("" + x[1]); }
        }

        object IObjectOperation.ReturnType
        {
            get { return b; }
        }

        #endregion

        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            return this;
        }

        #endregion

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.RightLeft; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            if (s is BinarySymbol)
            {
                char c = s.Symbol;
                if (c == '=')
                {
                    return Object;
                }
                if (c == '\u2260')
                {
                    return StringObjectUnequalityOperation.Object;
                }
            }
            return null;
        }

        #endregion
    }
}
