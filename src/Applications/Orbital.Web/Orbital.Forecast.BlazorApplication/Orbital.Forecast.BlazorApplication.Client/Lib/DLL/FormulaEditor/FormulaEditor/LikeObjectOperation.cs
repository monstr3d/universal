using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// Like object operation (wrapper of string like)
    /// </summary>
    public class LikeObjectOperation : IObjectOperation, IBinaryAcceptor
    {

        private static readonly Boolean b = false;

        private static readonly object[] types = new object[] { "", "" };

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly LikeObjectOperation Object =
            new LikeObjectOperation();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected LikeObjectOperation()
        {
        }

        #region IObjectOperation Members


        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return LikeOperation.Like(x[0], x[1]); }
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
