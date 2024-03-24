using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Transformation of function to its derivation
    /// </summary>
    public class DerivationTransformation : IOperationAcceptor, ITreeTransformation
    {

        #region Fields

        /// <summary>
        /// Default derivation
        /// </summary>
        public static readonly DerivationTransformation Derivation = new DerivationTransformation("");

        /// <summary>
        /// Derivation parameter
        /// </summary>
        string der;
        
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="der">Derivation variable name</param>
        public DerivationTransformation(string der)
        {
            this.der = der;
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return null;
        }

        #endregion

        #region ITreeTransformation Members

        ObjectFormulaTree ITreeTransformation.Transform(ObjectFormulaTree tree)
        {
            return tree.Derivation(der);
        }

        #endregion
    }
}
