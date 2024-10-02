using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    class StringObjectUnequalityOperation : IObjectOperation, IBinaryAcceptor
    {

        static private readonly Boolean b = false;

        static internal readonly StringObjectUnequalityOperation Object
            = new StringObjectUnequalityOperation();

        protected StringObjectUnequalityOperation()
        {
        }
        
        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get 
            {
                return new object[] { new object(), new object() };
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return !("" + x[0]).Equals("" + x[1]); }
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
    }
}
