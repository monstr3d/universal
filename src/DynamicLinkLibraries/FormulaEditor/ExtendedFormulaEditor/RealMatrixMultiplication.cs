using System;
using System.Collections.Generic;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using RealMatrixProcessor;

namespace FormulaEditor
{
    public class RealMatrixMultiplication : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {
        #region Fields


        internal static readonly RealMatrixMultiplication Singleton = new RealMatrixMultiplication();

        static private readonly IBinaryAcceptor[] acceptors = new IBinaryAcceptor[] { VectorScalarProduct.Object, ScalarProduct.Singleton };

        ArrayReturnType type;

        double[,] buffer;

        const Double a = 0;

        #endregion

        #region Ctor

        private RealMatrixMultiplication()
        {
        }

        private RealMatrixMultiplication(ArrayReturnType type)
        {
            this.type = type;
            int[] n = type.Dimension;
            buffer = new double[n[0], n[1]];

        }

        #endregion

        #region IObjectOperation Members

        public virtual object[] InputTypes
        {
            get { return new object[2]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                double[,] a = x[0] as double[,];
                double[,] b = x[1] as double[,];
                StaticExtensionRealMatrix.Multiply(a, b, buffer);
                return buffer;
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion

        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            IObjectOperation oo = ObjectFormulaTree.GetOperation(acceptors, typeA, typeB);
            if (oo != null)
            {
                return oo;
            }
            Double a = 0;
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
                ats[i] = at;
                if (at.Dimension.Length != 2)
                {
                    if (i == 1)
                    {
                        goto MatVec;
                    }
                }
            }
            if (ats[0].Dimension[1] != ats[1].Dimension[0])
            {
                return null;
            }
            int[] n = new int[] { ats[0].Dimension[0], ats[1].Dimension[1] };
            ArrayReturnType type = new ArrayReturnType(a, n, false);
            return new RealMatrixMultiplication(type);
            MatVec:
            if (ats[1].Dimension.Length != 1)
            {
                return null;
            }
            if (ats[0].Dimension.Length != 2)
            {
                return null;
            }
            if (ats[0].Dimension[1] != ats[1].Dimension[0])
            {
                return null;
            }
            return new RealVectorMatrixMultiplication(ats[0].Dimension[0]);
        }

        #endregion

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.RightLeft; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            if (s.Symbol == '*')
            {
                return this;
            }
            return null;
        }

        #endregion

        #region Specific Members

        IObjectOperation DetectMatrixVectorProduct(object typeA, object typeB)
        {
            if (typeA is ArrayReturnType & typeB is ArrayReturnType)
            {
                ArrayReturnType at = typeA as ArrayReturnType;
                ArrayReturnType bt = typeB as ArrayReturnType;
                if (at.ElementType.Equals(a) & bt.ElementType.Equals(a) & !at.IsObjectType & !bt.IsObjectType)
                {
                    if (at.Dimension.Length == 2 & bt.Dimension.Length == 1)
                    {
                        if (at.Dimension[1] == bt.Dimension[0])
                        {
                            return new RealVectorMatrixMultiplication(bt.Dimension[0]);
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
