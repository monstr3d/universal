using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Acceptor of multivariable elementary function
    /// </summary>
    public class ElementaryFunctionAcceptor : IMultiVariableOperationAcceptor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly ElementaryFunctionAcceptor Object = new ElementaryFunctionAcceptor();

        /// <summary>
        /// Constructor
        /// </summary>
        private ElementaryFunctionAcceptor()
        {
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object[] type)
        {
            return null;
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            return null;
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Accepted operation</returns>
        public IMultiVariableOperation AcceptOperation(MathSymbol symbol)
        {
            if (symbol is RootSymbol)
            {
                return new ElementaryRoot();
            }
            if (symbol.Symbol == '2')
            {
                return BinaryBrackets.Singleton;
            }
            if (symbol.Symbol == '3')
            {
                return TernaryBrackets.Singleton;
            }
            return ElementaryAtan2.Object;
        }
    }

}
