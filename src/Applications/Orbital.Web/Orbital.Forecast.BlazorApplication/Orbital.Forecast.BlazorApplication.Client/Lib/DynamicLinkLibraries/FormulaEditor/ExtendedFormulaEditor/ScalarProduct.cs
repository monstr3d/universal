using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{ 
    /// <summary>
    /// Scalar product of vectors
    /// </summary>
    public class ScalarProduct : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {
        #region Fields

        static private readonly Double type = 0;

        static internal readonly ScalarProduct Singleton = new ScalarProduct();

        #endregion

        #region Ctor

        private ScalarProduct()
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
                double c = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    c += a[i] * b[i];
                }
                return c;
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
            return null;
          /* !!! Scalar product should be replaced by SUM  if (!(typeA is ArrayReturnType & typeB is ArrayReturnType))
            {
                return null;
            }
            ArrayReturnType ta = typeA as ArrayReturnType;
            ArrayReturnType tb = typeB as ArrayReturnType;
            if (ta.IsObjectType | tb.IsObjectType)
            {
                return null;
            }
            if (!ta.ElementType.Equals(type) | !tb.ElementType.Equals(type))
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
            return this;
           * */
        }

        #endregion

        #region IBinaryDetector Members

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get { return BinaryAssociationDirection.LeftRight; }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol s)
        {
            if (s.Symbol.Equals("*"))
            {
                return ScalarProduct.Singleton;
            }
            return null;
        }

        #endregion
    }
}
