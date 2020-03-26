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
    /// Elementary real variable
    /// </summary>
    public class ElementaryObjectVariable : IObjectOperation, IPowered, IOperationAcceptor,
        IFormulaCreatorOperation, ICloneable, IDerivationOperation
    {
        /// <summary>
        /// Return type
        /// </summary>
        private object type;

        /// <summary>
        /// Value
        /// </summary>
        private object val;

        /// <summary>
        /// Operation symbol
        /// </summary>
        private object symbol;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        public ElementaryObjectVariable(object symbol)
        {
            Double a = 0;
            type = a;
            this.symbol = symbol;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <param name="type">Operation type</param>
        public ElementaryObjectVariable(object symbol, object type)
        {
            this.symbol = symbol;
            this.type = type;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <param name="table">Table of variables</param>
        public ElementaryObjectVariable(char symbol, Dictionary<char, object> table)
        {
            this.symbol = symbol;
            type = table[symbol];
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new ElementaryObjectVariable(symbol, type);
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
            MathSymbol sym = null;
            if (symbol is Char)
            {
                sym = new SimpleSymbol((char)symbol);
            }
            else if (symbol is StringPair)
            {
                StringPair sp = symbol as StringPair;
                sym = new SubscriptedSymbol(sp.First, sp.Second);
            }
            sym.Append(form);
            return form;
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
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="s">Derivation string</param>
        /// <returns>The derivation</returns>
        public ObjectFormulaTree Derivation(ObjectFormulaTree tree, string s)
        {
            double val = 0;
            if (s.Length == 1)
            {
                if (symbol is Char)
                {
                    char ch = (char)symbol;
                    if (s[0] == ch)
                    {
                        val = 1;
                    }
                }
            }
            ElementaryRealConstant op = new ElementaryRealConstant(val);
            return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());
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
                return type;
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
        public object Value
        {
            set
            {
                val = value;
            }
        }

        /// <summary>
        /// Operation symbol
        /// </summary>
        public object Symbol
        {
            get
            {
                return symbol;
            }
        }



        #region IDerivationOperation Members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
        {
            Double a = 0;
            double val = 0;
            bool zero = false;
            if (ReturnType.Equals(a))
            {
                zero = true;
                if (s.Length == 1)
                {
                    if (symbol is Char)
                    {
                       if (s[0] == (char)symbol)
                        {
                            val = 1;
                            zero = false;
                        }
                    }
                }
            }
            if (zero)
            {
                return ElementaryRealConstant.RealZero;
            }
            ElementaryRealConstant op = new ElementaryRealConstant(val);
            return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());
        }

        #endregion
    }

}
