using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of null arity real operation
    /// </summary>
    public class ElementaryRealDetector : IOperationDetector
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ElementaryRealDetector Object = new ElementaryRealDetector();

        /// <summary>
        /// Constructor
        /// </summary>
        protected ElementaryRealDetector()
        {
        }

        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="s">First symbol of the formula</param>
        /// <returns>Acceptor of operation</returns>
        public virtual IOperationAcceptor Detect(MathSymbol s)
        {
            if (s.Symbol == '~')
            {
                return new BitwiseOperation();
            }
            if (s.Symbol == '¬')
            {
                return NegationOperation.Object;
            }
            if (s.Symbol == '-')
            {
                return Minus;
            }
            if (s is SeriesSymbol)
            {
                SeriesSymbol ss = s as SeriesSymbol;
                if (ss.Acceptor is IUnary)
                {
                    return new ElementaryUnaryOperation(ss.Acceptor as IUnary, ss.Index);
                }
                return ss.Acceptor;
            }
            if (s is BinaryFunctionSymbol)
            {
                return ElementaryAtan2.Object;
            }
            if (s is RootSymbol)
            {
                return new ElementaryRoot();
            }
            if (s is FractionSymbol)
            {
                return ElementaryFraction.Object;
            }
            if (s is BracketsSymbol)
            {
                return Brakets;
            }
            if (s is AbsSymbol)
            {
                return new ElementaryAbs();
            }
            if (s.SymbolType == (byte)FormulaConstants.Variable)
            {
                if (s.Symbol == '%')
                {
                    return new TranscredentRealConstant('p');
                }
                if (s.Symbol == 'e')
                {
                    return new TranscredentRealConstant('e');
                }
                return new ElementaryObjectVariable(s.Symbol);
            }
            if (s.SymbolType == (byte)FormulaConstants.Number)
            {
                return new ElementaryRealConstant(s.DoubleValue);
            }
            if (s.SymbolType == (byte)FormulaConstants.Unary & s.Symbol != '\u2211' & !(s.Symbol + "").Equals("'"))
            {
                string str = s.Symbol + "";
                if (str.Equals(str.ToLower()))
                {
                    return new ElementaryFunctionOperation(s.Symbol);
                }
                return new ElementaryIntegerOperation(s.Symbol);
            }
            if (s is SimpleSymbol)
            {
                SimpleSymbol ss = s as SimpleSymbol;
                if (!ss.Bold & !ss.Italic)
                {
                    return new StringOperationAcceptor(ss.String);
                }
            }

            return null;
        }

        /// <summary>
        /// Minus operation
        /// </summary>
        protected virtual IOperationAcceptor Minus
        {
            get
            {
                return new ElementaryFunctionOperation('-');
            }
        }

        /// <summary>
        /// Brakets operation
        /// </summary>
        protected virtual ElementaryBrackets Brakets
        {
            get
            {
                return new ElementaryBrackets(null);
            }
        }
    }
}
