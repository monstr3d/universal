using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary ULong constant
    /// </summary>
    public class ElementaryULongConstant : IObjectOperation, IOperationAcceptor, IFormulaCreatorOperation,
        IDerivationOperation
    {
        /// <summary>
        /// Return type
        /// </summary>
        private const UInt64 a = 0;

        /// <summary>
        /// Value
        /// </summary>
        private ulong val;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">Value</param>
        public ElementaryULongConstant(ulong val)
        {
            this.val = val;
        }

        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="s">Derivation string</param>
        /// <returns>The derivation</returns>
        public ObjectFormulaTree Derivation(ObjectFormulaTree tree, string s)
        {
            ElementaryRealConstant op = new ElementaryRealConstant(0);
            return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());
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
            return new MathFormula(level, sizes, val);
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Variable;
            }
        }



        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return val;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return a;
            }
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            return this;
        }


        /// <summary>
        /// Sets value
        /// </summary>
        public ulong Value
        {
            set
            {
                val = value;
            }
        }
    }

}
