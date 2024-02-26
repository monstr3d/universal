using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Acceptor of equality opreation
    /// </summary>
    public class InequalityAcceptor : IBinaryAcceptor
    {
        /// <summary>
        /// The singleton
        /// </summary>
        public static readonly InequalityAcceptor Object = new InequalityAcceptor();

        /// <summary>
        /// Constructor
        /// </summary>
        private InequalityAcceptor()
        {
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (!typeA.Equals(typeB))
            {
                throw new Exception("Different types in inequality");
            }
            return InequalityOperation.Object;
        }
    }
}
