using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Inequality operation
    /// </summary>
    public class InequalityOperation : IObjectOperation, IFormulaCreatorOperation
    {

        /// <summary>
        /// Variable for type definition
        /// </summary>
        private const Boolean b = false;

        /// <summary>
        /// The singleton
        /// </summary>
        public static readonly InequalityOperation Object = new InequalityOperation();

        private static readonly object[] types = new object[] { new object(), new object() };

        /// <summary>
        /// Constructor
        /// </summary>
        private InequalityOperation()
        {
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return !x[0].Equals(x[1]);
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return b;
            }
        }

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        public MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            return OptionalOperation.CreateFormula(this, tree, level, sizes, "\u2260");
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Comparation;
            }
        }


    }
}
