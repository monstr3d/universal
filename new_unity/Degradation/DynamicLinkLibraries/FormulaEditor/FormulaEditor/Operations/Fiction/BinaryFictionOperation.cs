using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using BaseTypes.Attributes;
using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Operations.Fiction
{
    [Attributes.Fiction]
    class BinaryFictionOperation : IObjectOperation, IInternalOperation
    {
        IObjectOperation ownOperation;

        object[] input;

        object retType;

        internal BinaryFictionOperation(IObjectOperation ownOperation, object typeA, object typeB)
        {
            this.ownOperation = ownOperation;
            input = new object[] { typeA, typeB };
            retType = new ArrayReturnType(ownOperation.ReturnType, new int[] { -1 }, true);
        }

        #region IObjectOperation Members

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return input;
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return retType;
            }
        }

        #endregion

        #region IInternalOperation Members

        IObjectOperation IInternalOperation.Operation
        {
            get
            {
                return ownOperation;
            }
        }

        #endregion
    }
}
