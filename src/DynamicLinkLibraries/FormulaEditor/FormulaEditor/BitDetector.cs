using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of binary operations
    /// </summary>
    public class BitDetector : IBinaryDetector
    {

        /// <summary>
        /// Detected symbol
        /// </summary>
        private char symbol;

        /// <summary>
        /// Constructor
        /// </summary>
        public BitDetector(char symbol)
        {
            this.symbol = symbol;
        }

        /// <summary>
        /// Association direction
        /// </summary>
        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.RightLeft;
            }
        }

        /// <summary>
        /// Detects operation acceptor
        /// </summary>
        /// <param name="s">Operation symbol</param>
        /// <returns>The acceptor</returns>
        public IBinaryAcceptor Detect(MathSymbol s)
        {
            if (s is BinarySymbol)
            {
                char c = s.Symbol;
                if ((c == symbol))
                {
                    return new BitOperation(c);
                }
            }
            return null;
        }
    }
}
