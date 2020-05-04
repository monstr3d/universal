using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Interfaces;
using BaseTypes.Interfaces;

namespace FormulaEditor.Variables
{
    /// <summary>
    /// Double variable
    /// </summary>
    public class VariableDouble : Variable, IDerivationOperation
    {

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="variableName">Name of variable</param>
        public VariableDouble(string variableName)
            : base((double)0, variableName)
        {
        }

        #endregion

        #region IDerivationOperation Members

        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The tree for derivation calculation</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>The derivation tree</returns>
        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string variableName)
        {
            
            if (variableName.Equals("d/d" + this.variableName))
            {
                // If name of variable is equal to differential variable
                // Then returns 1
                return new ObjectFormulaTree(new Unity(), new List<ObjectFormulaTree>());
            }
            // Returns 0
            return new ObjectFormulaTree(new Zero(), new List<ObjectFormulaTree>());
        }

        #endregion

        #region Helper classes

        /// <summary>
        /// Unity operation, returns 1 always
        /// </summary>
        class Unity : IObjectOperation, IDerivationOperation
        {

            const Double a = 0;

            const Double b = 1;

            object[] inputs = new object[0];

            static ObjectFormulaTree tree;

            internal Unity()
            {
            }

            object[] IObjectOperation.InputTypes
            {
                get { return inputs; }
            }

            /// <summary>
            /// Calculates operation result
            /// </summary>
            /// <param name="x">Argument</param>
            /// <returns>Result</returns>
            public virtual object this[object[] x]
            {
                get { return b; }
            }

            object IObjectOperation.ReturnType
            {
                get { return a; }
            }

            static Unity()
            {
                tree = new ObjectFormulaTree(new Zero(), new List<ObjectFormulaTree>());
            }

            ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
            {
                return tree;
            }
        }

        /// <summary>
        /// Zero operation, returns 0 always
        /// </summary>
        class Zero : Unity
        {
            const Double c = 0;

            public override object this[object[] x]
            {
                get
                {
                    return c;
                }
            }
        }

        #endregion
    }
}
