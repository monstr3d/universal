using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of equality operator
    /// </summary>
    public class LogicalEqualityDetector : IBinaryDetector
    {

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly LogicalEqualityDetector Object = new LogicalEqualityDetector();

        /// <summary>
        /// Constructor
        /// </summary>
        protected LogicalEqualityDetector()
        {

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
                if (c == '=')
                {
                    return EqualityAcceptor.Object;
                }
                if (c == '\u2260')
                {
                    return InequalityAcceptor.Object;
                }
            }
            return null;
        }
    }

}
