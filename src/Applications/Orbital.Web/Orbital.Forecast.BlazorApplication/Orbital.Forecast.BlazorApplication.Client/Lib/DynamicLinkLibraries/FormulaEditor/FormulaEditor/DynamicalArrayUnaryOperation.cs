using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Unary operation with dynamical array
    /// </summary>
    class DynamicalArrayUnaryOperation : IObjectOperation, IInternalOperation
    {
        #region Fields

        ArrayReturnType[] types;

        ArrayReturnType type;

        IObjectOperation op;

        object[] t = new object[1];

        int[] k = new int[1];

        #endregion

        #region Ctor

        internal DynamicalArrayUnaryOperation(ArrayReturnType type, IObjectOperation op)
        {
            types = new ArrayReturnType[] { type };
            this.type = new ArrayReturnType(op.ReturnType, type.Dimension, type.IsObjectType);
            this.op = op;
        }

        #endregion

        #region IObjectOperation Members

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                Array a = arguments[0] as Array;
                int n = a.Length;
                object[] r = new object[n];
                for (int i = 0; i < n; i++)
                {
                    k[0] = i;
                    t[0] = a.GetValue(k);
                    r[i] = op[t];
                }
                return r;
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return type;
            }
        }

        IObjectOperation IInternalOperation.Operation
        {
            get
            {
                return op;
            }
        }

        #endregion
    }
}
