using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Detector of binary operations
    /// </summary>
    public interface IBinaryDetector
    {

        /// <summary>
        /// Association direction
        /// </summary>
        BinaryAssociationDirection AssociationDirection
        {
            get;
        }

        /// <summary>
        /// Detects operation acceptor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <returns>The acceptor</returns>
        IBinaryAcceptor Detect(MathSymbol symbol);
    }
}
