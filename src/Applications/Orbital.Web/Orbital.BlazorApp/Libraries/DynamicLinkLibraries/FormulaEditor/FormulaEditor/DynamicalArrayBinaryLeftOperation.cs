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
    class DynamicalArrayBinaryLeftOperation : IObjectOperation, IInternalOperation
    {

        #region Fields

        ArrayReturnType type;

        IObjectOperation op;

        object[] types;

        object[] t = new object[2];

        int[] k = new int[1];

        #endregion

        #region Ctor

        internal DynamicalArrayBinaryLeftOperation(object typeA, object typeB, IObjectOperation op)
        {
            types = new object[] { typeA, typeB };
            ArrayReturnType art = typeA as ArrayReturnType;
            type = new ArrayReturnType(op.ReturnType, art.Dimension, art.IsObjectType);
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
                t[1] = arguments[1];
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

        #endregion

        #region IInternalOperation Members

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

