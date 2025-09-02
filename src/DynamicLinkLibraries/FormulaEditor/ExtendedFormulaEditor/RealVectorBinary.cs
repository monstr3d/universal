using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;
using ErrorHandler;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
    public class RealVectorBinary : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {

        #region Fields

        internal static RealVectorBinary Singleton = new RealVectorBinary();

        const Double a = 0;

        ArrayReturnType type;

        protected double[] buffer;

        #endregion

        #region Ctor

        protected RealVectorBinary()
        {
        }

        protected RealVectorBinary(int dim)
        {
            buffer = new double[dim];
            type = new ArrayReturnType(a, new int[] { dim }, false);
        }

        #endregion

        #region IObjectOperation Members

        public virtual object[] InputTypes
        {
            get { return new object[2]; }
        }

        public virtual object this[object[] x]
        {
            get { throw new OwnException("The method or operation is not implemented."); }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion


        protected virtual RealVectorBinary CreateOperation(int dim)
        {
            return null;
        }

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
                if (at.Dimension.Length != 1)
                {
                    return null;
                }
                ats[i] = at;
            }
            if (ats[0].Dimension[0] != ats[1].Dimension[0])
            {
                return null;
            }
            int dim = ats[0].Dimension[0];
            return CreateOperation(dim);
        }

        #endregion

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.RightLeft; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            char c = s.Symbol;
            if (c == '+')
            {
                return RealVectorAdd.Singleton;
            }
            if (c == '-')
            {
                return RealVectorDifference.Singleton;
            }
            return null;
        }

        #endregion
    }
}