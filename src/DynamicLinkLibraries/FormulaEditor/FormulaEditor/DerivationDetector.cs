using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Attributes;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of derivations
    /// </summary>
    [TreeTransformation()]
    public class DerivationDetector : IOperationDetector
    {
        #region Fields


        private string detected;


        private string der;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detected">Detected derivation string</param>
        /// <param name="der">Derivation variable string</param>
        public DerivationDetector(string detected, string der)
        {
            this.detected = detected;
            this.der = der;
        }

        #endregion

        #region IOperationDetector Members

        IOperationAcceptor IOperationDetector.Detect(MathSymbol s)
        {
            if (s.String.Equals(detected))
            {
                return new DerivationTransformation(der);
            }
            return null;
        }

        #endregion

    }
}
