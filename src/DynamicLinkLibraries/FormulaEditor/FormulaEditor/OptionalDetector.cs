using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;
using ErrorHandler;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Conditional oprearation detector
    /// </summary>
    public class OptionalDetector : IMultiOperationDetector
    {
        /// <summary>
        /// Conditional type
        /// </summary>
        const Boolean type = false;

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly OptionalDetector Object = new OptionalDetector();


        /// <summary>
        /// Constructor
        /// </summary>
        protected OptionalDetector()
        {
        }

        /// <summary>
        /// The "has begin" sign
        /// </summary>
        public bool HasBegin
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The "has end" sign
        /// </summary>
        public bool HasEnd
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Count of arguments
        /// </summary>
        public int Count
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Detects i - th symbol of operation
        /// </summary>
        /// <param name="i">The symbol number</param>
        /// <param name="symbol">Symbol of detection</param>
        /// <returns></returns>
        public bool Detect(int i, MathSymbol symbol)
        {
            if (!(symbol is BinarySymbol))
            {
                return false;
            }
            char c = symbol.Symbol;
            if (i == 0)
            {
                return c == '?';
            }
            else
            {
                return c == ':';
            }
        }


        /// <summary>
        /// Accept operation
        /// </summary>
        /// <param name="types">Types of operands</param>
        /// <returns>Operation</returns>
        public IObjectOperation Accept(object[] types)
        {
            if (types[0].Equals(type))
            {
                if (types[1].Equals(types[2]))
                {
                    return new OptionalOperation(types[1]);
                }
                else
                {
                    throw new ErrorHandler.OwnException("Imcompatible types of optional operation");
                }
            }
            return null;
        }
    }

}
