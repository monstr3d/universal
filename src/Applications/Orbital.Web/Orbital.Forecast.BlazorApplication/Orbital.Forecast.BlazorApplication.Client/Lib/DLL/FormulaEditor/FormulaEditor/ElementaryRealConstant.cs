using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary real constant
    /// </summary>
    public class ElementaryRealConstant : IObjectOperation, IPowered, IOperationAcceptor, IFormulaCreatorOperation,
        IDerivationOperation, ISupportsZero,  IStringConstantValue
    {

        #region Fields

        /// <summary>
        /// Return type
        /// </summary>
        private const Double a = 0;

        /// <summary>
        /// Value
        /// </summary>
        private double val;

        /// <summary>
        /// Zero tree
        /// </summary>
        public static readonly ObjectFormulaTree RealZero = NullTree;


        /// <summary>
        /// The "is zepo singn
        /// </summary>
        private bool isZero = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">Value of constant</param>
        public ElementaryRealConstant(double val)
        {
            this.val = val;
        }


        #endregion

        #region IDerivationOperation Members

        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>The derivation</returns>
        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string variableName)
        {
            return RealZero;
        }

        #endregion

        #region IStringConstantValue Members

        /// <summary>
        /// IStringConstantValue Members
        /// </summary>
        string IStringConstantValue.Value => StringValue;

        #endregion


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
        object[] IObjectOperation.InputTypes
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
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
        {
            get
            {
                return true;
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
        public double Value
        {
            set
            {
                val = value;
            }
            get
            {
                return val;
            }
        }

        /// <summary>
        /// Creates tree from double constant
        /// </summary>
        /// <param name="d">Double constant</param>
        /// <returns>Constant tree</returns>
        public static ObjectFormulaTree GetConstant(double d)
        {
            ElementaryRealConstant c = new ElementaryRealConstant(d);
            return new ObjectFormulaTree(c, new List<ObjectFormulaTree>());
        }

        /// <summary>
        /// Zero tree
        /// </summary>
        static private ObjectFormulaTree NullTree
        {
            get
            {
                ElementaryRealConstant op = new ElementaryRealConstant(0);
                op.isZero = true;
                return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());

            }
        }

        #region ISupportsZero Members

        bool ISupportsZero.IsZero(ObjectFormulaTree tree)
        {
            return isZero;
        }

        #endregion

        /// <summary>
        /// String representation of constant
        /// </summary>
        public virtual string StringValue
        {
            get
            {
                string s = val + "";
                return s.Replace(MathSymbol.DecimalSep[0], '.');
            }
        }

   
    }
}
