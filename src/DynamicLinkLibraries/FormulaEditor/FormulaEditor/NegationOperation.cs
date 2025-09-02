using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;
using ErrorHandler;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Negation operation
    /// </summary>
    public class NegationOperation : IObjectOperation, IOperationAcceptor,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly NegationOperation Object = new NegationOperation();

        /// <summary>
        /// Type of operation
        /// </summary>
        static private Boolean a = false;

        private NegationOperation()
        {
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
            MathFormula form = new MathFormula(level, sizes);
            MathFormula f = new MathFormula(level, sizes);
            MathSymbol sym = new SimpleSymbol('¬', (byte)FormulaConstants.Unary, false, "¬");
            sym.Append(form);
            sym = new BracketsSymbol();
            sym.Append(form);
            form.Last[0] = FormulaCreator.CreateFormula(tree[0], level, sizes);
            return form;
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Function;
            }
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { a };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return unaryValue(x[0]);
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
            if (!a.Equals(type))
            {
                throw new ErrorHandler.OwnException("Argument of negation operation should be boolean");
            }
            return this;
        }

 
        /// <summary>
        /// Calculates value of integer operation
        /// </summary>
        /// <param name="x">the argument</param>
        /// <returns>The value</returns>
        private object unaryValue(object x)
        {
            bool a = (bool)x;
            return !a;
        }
    }
}
