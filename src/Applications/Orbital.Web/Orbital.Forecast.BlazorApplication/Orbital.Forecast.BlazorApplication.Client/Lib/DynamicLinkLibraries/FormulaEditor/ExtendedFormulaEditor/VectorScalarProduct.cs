using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    public class VectorScalarProduct : ScalarVectorProduct, IBinaryAcceptor
    {

        static private readonly Double a = 0;

        internal static readonly VectorScalarProduct Object = new VectorScalarProduct(-1);

        private VectorScalarProduct(int dimension)
            : base(dimension)
        {
        }

        public override object this[object[] x]
        {
            get
            {
                double[] a = x[0] as double[];
                double b = (double)x[1];
                for (int i = 0; i < a.Length; i++)
                {
                    result[i] = a[i] * b;
                }
                return result;
            }
        }

        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            int n = check(typeA, typeB);
            if (n > 0)
            {
                return new VectorScalarProduct(n);
            }
            n = check(typeB, typeA);
            if (n < 0)
            {
                return null;
            }
            return new ScalarVectorProduct(n);
        }

        #endregion

        static private int check(object ta, object tb)
        {
            if (!((ta is ArrayReturnType) & tb.Equals(a)))
            {
                return -1;
            }
            ArrayReturnType at = ta as ArrayReturnType;
            if (!at.ElementType.Equals(a) | at.IsObjectType)
            {
                return -1;
            }
            if (at.Dimension.Length != 1)
            {
                return -1;
            }
            return at.Dimension[0];

        }
    }
}
