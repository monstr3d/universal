using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of binary array operation
    /// </summary>
    public class BinaryArrayOperationDetector : IBinaryDetector
    {

        #region Fields

        /// <summary>
        /// Operation acceptor
        /// </summary>
        private IBinaryDetector detector;


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detector">Prototype detector</param>
        public BinaryArrayOperationDetector(IBinaryDetector detector)
        {
            this.detector = detector;
        }

        #endregion

        #region IBinaryDetector Members

        /// <summary>
        /// Association direction
        /// </summary>
        public FormulaEditor.BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return detector.AssociationDirection;
            }
        }

        /// <summary>
        /// Detects operation acceptor
        /// </summary>
        /// <param name="s">Operation symbol</param>
        /// <returns>The acceptor</returns>
        public IBinaryAcceptor Detect(MathSymbol s)
        {
            IBinaryAcceptor acc = detector.Detect(s);
            if (acc == null)
            {
                return null;
            }
            return new BinaryArrayOperationAcceptor(acc);
        }

        #endregion
    }
}
