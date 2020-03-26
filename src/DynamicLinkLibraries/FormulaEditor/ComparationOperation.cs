using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BaseTypes.Utils;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{

    ///Replace types with IComparable interface and compare the IComparable
    
    /// <summary>
    /// Comparation operation
    /// </summary>
    public class ComparationOperation : IObjectOperation, IBinaryAcceptor, ICloneable,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Type
        /// </summary>
        private const Boolean a = false;

        /// <summary>
        /// Type
        /// </summary>
        private char symbol;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public ComparationOperation(char symbol)
        {
            this.symbol = symbol;
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
                return (int)ElementaryOperationPriorities.Comparation;
            }
        }



        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new ComparationOperation(symbol);
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { (double)0, (double)0 };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                int i = 0;
                if (!ElementaryBinaryOperation.IsNegative(x[0]) & ElementaryBinaryOperation.IsNegative(x[1]))
                {
                    i = 1;
                }
                else if (ElementaryBinaryOperation.IsNegative(x[0]) & !ElementaryBinaryOperation.IsNegative(x[1]))
                {
                    i = -1;
                }
                if (!ElementaryBinaryOperation.IsInteger64(x[0]) | !ElementaryBinaryOperation.IsInteger64(x[0]))
                {
                    double a = Converter.ToDouble(x[0]);
                    double b = Converter.ToDouble(x[1]);
                    if (a > b)
                    {
                        i = 1;
                    }
                    if (a < b)
                    {
                        i = -1;
                    }
                }
                else
                {
                    long a = Converter.ToInt64(x[0]);
                    long b = Converter.ToInt64(x[1]);
                    if (a > b)
                    {
                        i = 1;
                    }
                    if (a < b)
                    {
                        i = -1;
                    }
                }
                if (symbol == '>')
                {
                    return i == 1;
                }
                if (symbol == '<')
                {
                    return i == -1;
                }
                if (symbol == '\u2260')
                {
                    return i != 0;
                }
                if (symbol == '\u2264')
                {
                    return i != 1;
                }
                if (symbol == '\u2265')
                {
                    return i != -1;
                }
                return false;
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
            IObjectOperation op = DateTimeMoreComparator.Object.Accept(typeA, typeB);
            if (op != null)
            {
                if (symbol == '>')
                {
                    return DateTimeMoreComparator.Object;
                }
                if (symbol == '<')
                {
                    return DateTimeLessCompatrator.Object;
                }
            }
            if (!ElementaryBinaryOperation.IsNumber(typeA) | !ElementaryBinaryOperation.IsNumber(typeB))
            {
                return null;
            }
            return this;
        }

        /// <summary>
        /// String representation of symbol
        /// </summary>
        public string String
        {
            get
            {
                return symbol + "";
            }
        }
    }
}
