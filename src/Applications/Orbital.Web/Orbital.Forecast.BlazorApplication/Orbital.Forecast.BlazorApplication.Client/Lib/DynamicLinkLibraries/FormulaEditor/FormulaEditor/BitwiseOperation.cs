using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
    /// <summary>
    /// Bitwise operation
    /// </summary>
    public class BitwiseOperation : IObjectOperation, IOperationAcceptor,
        IFormulaCreatorOperation
    {


        /// <summary>
        /// Type of operation
        /// </summary>
        private object type;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BitwiseOperation()
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
            MathSymbol sym = new SimpleSymbol('~', (byte)FormulaConstants.Unary, false, "~");
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
                return new object[] { type };
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
                return type;
            }
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            if (!ElementaryBinaryOperation.IsInteger(type))
            {
                return null;
            }
            this.type = type;
            return this;
        }

 
        /// <summary>
        /// Calculates value of integer operation
        /// </summary>
        /// <param name="x">the argument</param>
        /// <returns>The value</returns>
        private object unaryValue(object x)
        {
            if (type is SByte)
            {
                sbyte a = (sbyte)x;
                return ~a;
            }
            if (type is UInt16)
            {
                ushort a = (ushort)x;
                return ~a;
            }
            if (type is UInt32)
            {
                uint a = (uint)x;
                return ~a;
            }
            if (type is UInt64)
            {
                ulong a = (ulong)x;
                return ~a;
            }
            if (type is Byte)
            {
                byte a = (byte)x;
                return ~a;
            }
            if (type is Int16)
            {
                short a = (short)x;
                return ~a;
            }
            if (type is Int32)
            {
                int a = (int)x;
                return ~a;
            }
            if (type is Int64)
            {
                long a = (long)x;
                return ~a;
            }
            return null;
        }
    }
}
