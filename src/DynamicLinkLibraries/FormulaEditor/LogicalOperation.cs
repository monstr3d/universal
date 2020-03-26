using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// Conditional operation
    /// </summary>
    public class LogicalOperation : IObjectOperation, IBinaryAcceptor, ICloneable,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Type
        /// </summary>
        private const Boolean a = false;

        private Func<bool, bool, bool> func;

        private int prioriry;

        /// <summary>
        /// Type
        /// </summary>
        public char symbol;

        private Dictionary<char, object[]> dic =
            new Dictionary<char, object[]>()
            {
                {'\u2216' , new object[] {(int)ElementaryOperationPriorities.LogicalOR, new Func<bool, bool, bool>( (bool a, bool b)=>{ return a & b;})}},
                {'\u2217' , new object[] {(int)ElementaryOperationPriorities.LogicalOR, new Func<bool, bool, bool>((bool a, bool b)=>{ return a | b;})}},
                {'\u8835' , new object[] {(int)ElementaryOperationPriorities.LogicalOR, new Func<bool, bool, bool>((bool a, bool b)=>{ return !a | b;})}}
            };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public LogicalOperation(char symbol)
        {
            this.symbol = symbol;
            object[] o = dic[symbol];
            prioriry = (int)o[0];
            func = o[1] as Func<bool, bool, bool>;
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
            return OptionalOperation.CreateFormula(this, tree, level, sizes, symbol + "");
        }



        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return prioriry;
            }
        }



        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new LogicalOperation(symbol);
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { false, false };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                bool a = (bool)x[0];
                bool b = (bool)x[1];
                return func(a, b);
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
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (!a.Equals(typeA) | !a.Equals(typeB))
            {
                return null;
            }
            return this;
        }

        /// <summary>
        /// Operation symbol
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol;
            }
        }

    }
}
