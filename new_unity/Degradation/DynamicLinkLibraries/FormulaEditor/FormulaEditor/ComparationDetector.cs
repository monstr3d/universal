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
    public class ComparationDetector : IBinaryDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ComparationDetector Object = new ComparationDetector();

        /// <summary>
        /// Constructor
        /// </summary>
        protected ComparationDetector()
        {

        }

        /// <summary>
        /// Association direction
        /// </summary>
        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.LeftRight;
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
                if ((c == '>') | (c == '<') | (c == '\u2260') | (c == '\u2264') | (c == '\u2265'))
                {
                    return new ComparationOperation(c);
                }
            }
            return null;
        }
    }
}
