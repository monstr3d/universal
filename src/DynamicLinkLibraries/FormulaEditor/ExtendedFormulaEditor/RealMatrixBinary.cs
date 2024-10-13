using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using RealMatrixProcessor;


namespace FormulaEditor
{
    public class RealMatrixBinary : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {

        #region Fields
        const Double a = 0;
        ArrayReturnType type;

        protected double[,] buffer;

        protected RealMatrix realMatrix = new();

        internal static readonly RealMatrixBinary Singleton = new RealMatrixBinary();

        #endregion

        #region Ctor

        private RealMatrixBinary()
        {
        }

        internal RealMatrixBinary(int row, int col)
        {
            buffer = new double[row, col];
            type = new ArrayReturnType(a, new int[] { row, col }, false);
        }

        #endregion

        #region IObjectOperation Members


        /// <summary>
        /// Types of input parameters
        /// </summary>
        public virtual object[] InputTypes
        {
            get
            {
                return new object[2]; ;
            }
        }

        public virtual object this[object[] x]
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion

        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            object[] t = new object[] { typeA, typeB };
            ArrayReturnType[] ats = new ArrayReturnType[2];
            for (int i = 0; i < t.Length; i++)
            {
                object ty = t[i];
                if (!(ty is ArrayReturnType))
                {
                    return null;
                }
                ArrayReturnType at = ty as ArrayReturnType;
                if (at.IsObjectType)
                {
                    return null;
                }
                if (!at.ElementType.Equals(a))
                {
                    return null;
                }
                if (at.Dimension.Length != 2)
                {
                    return null;
                }
                ats[i] = at;
            }
            if (ats[0].Dimension[0] != ats[1].Dimension[0] | ats[0].Dimension[1] != ats[1].Dimension[1])
            {
                return null;
            }
            int[] dim = ats[0].Dimension;
            return CreateOpreation(dim[0], dim[1]);
        }

        #endregion

        protected virtual RealMatrixBinary CreateOpreation(int row, int col)
        {
            return null;
        }

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.LeftRight; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            char c = s.Symbol;
            if (c == '+')
            {
                return RealMatrixAdd.Singleton;
            }
            if (c == '-')
            {
                return RealMatixDifference.Singleton;
            }
            return null;
        }

        #endregion
    }
}
