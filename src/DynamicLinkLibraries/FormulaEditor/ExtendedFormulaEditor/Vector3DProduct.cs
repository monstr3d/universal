using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    public class Vector3DProduct : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {
        #region Fields

        static private readonly Double a = 0;

        static private readonly ArrayReturnType type = new ArrayReturnType(a, new int[]{3}, false);

        static internal readonly Vector3DProduct Object = new Vector3DProduct();

        double[] result = new double[3];

        #endregion

        #region Ctor

        private Vector3DProduct()
        {
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
                double[] a = x[0] as double[];
                double[] b = x[1] as double[];
                result[0] = a[1] * b[2] - a[2] * b[1];
                result[1] = a[2] * b[0] - a[0] * b[2];
                result[2] = a[0] * b[1] - a[1] * b[0];
                return result;
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
            if (!(typeA is ArrayReturnType & typeB is ArrayReturnType))
            {
                return null;
            }
            ArrayReturnType ta = typeA as ArrayReturnType;
            ArrayReturnType tb = typeB as ArrayReturnType;
            if (ta.IsObjectType | tb.IsObjectType)
            {
                return null;
            }
            if (!ta.ElementType.Equals(a) | !tb.ElementType.Equals(a))
            {
                return null;
            }
            if (ta.Dimension.Length != 1 | tb.Dimension.Length != 1)
            {
                return null;
            }
            if (ta.Dimension[0] != tb.Dimension[0])
            {
                return null;
            }
            return new Vector3DProduct();
        }

        #endregion

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.LeftRight; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            if (s.Symbol == '×')
            {
                return Vector3DProduct.Object;
            }
            return null;
        }

        #endregion
    }
}
