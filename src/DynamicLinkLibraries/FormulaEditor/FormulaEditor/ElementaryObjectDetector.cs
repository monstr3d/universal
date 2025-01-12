using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
	/// <summary>
	/// Elementary object detector
	/// </summary>
	public class ElementaryObjectDetector : ElementaryRealDetector, IVariableDetector
    {

        #region Fields

        /// <summary>
		/// Table of variable types
		/// </summary>
		private Dictionary<char, object> table;

        /// <summary>
        /// Detector
        /// </summary>
        private IVariableDetector detector;


        #endregion

        #region Ctor

        /// <summary>
		/// Constructor
		/// </summary>
		/// <param name="table">Table of variable types</param>
		public ElementaryObjectDetector(Dictionary<char, object> table)
		{
			this.table = table;
            detector = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detector">Detector of variable</param>
        public ElementaryObjectDetector(IVariableDetector detector)
        {
            this.detector = detector;
        }

        #endregion

        #region Overridens

        /// <summary>
		/// Detects operation
		/// </summary>
		/// <param name="s">First symbol of the formula</param>
		/// <returns>Acceptor of operation</returns>
		public override IOperationAcceptor Detect(MathSymbol s)
		{
			//Double a = 0;
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
            if (s.Symbol == '\u03B4')
            {
                return new DeltaFunction();
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
            if (s is TernaryFunctionSymbol)
            {
                if (s.Symbol == '3')
                {
                    return TernaryBrackets.Singleton;
                }
            }
			if (s is BinaryFunctionSymbol)
			{
                if (s.Symbol == '2')
                {
                    return BinaryBrackets.Singleton;
                }
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
			if (s is SubscriptedSymbol)
			{
				SubscriptedSymbol sym = s as SubscriptedSymbol;
                if (table != null)
                {
                }
				return new ElementaryObjectVariable(sym.Pair, table);
			}
			if (s.SymbolType == (byte)FormulaConstants.Boolean)
			{
                if (s.String.Equals("True"))
                {
                    return new BooleanConstant(true);
                }
                if (s.String.Equals("False"))
                {
                    return new BooleanConstant(false);
                }

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
                IOperationAcceptor var = detector.Detect(s);
                if (var != null)
                {
                    return var;
                }
                else
                {
                    return null;
                }
			}
			if (s.SymbolType == (byte)FormulaConstants.Number)
			{
				if (s.Symbol == '?')
				{
					return new ElementaryRealConstant(s.DoubleValue);
				}
				else
				{
					return new ElementaryULongConstant(s.ULongValue);
				}
			}
            if (s.SymbolType == (byte)FormulaConstants.Unary & s.Symbol != '\u2211' & !(s.Symbol + "").Equals("'"))
			{
				string str = s.Symbol + "";
				if (str.Equals(str.ToLower()))
				{
                    if (s.Symbol == 'w')
                    {
                        return new TimeOperation();
                    }
                    if (s.Symbol == 'o')
                    {
                        return TimeToDoubleOperation.Object;
                    }
					return new ElementaryFunctionOperation(s.Symbol);
				}
				return new ElementaryIntegerOperation(s.Symbol);
			}
			return null;
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor IVariableDetector.Detect(MathSymbol sym)
        {
            if (table != null)
            {
                if (!table.ContainsKey(sym.Symbol))
                {
                    return null;
                }
                return new ElementaryObjectVariable(sym.Symbol, table);
            }
            return null;
        }

        #endregion

        #region Members

        /// <summary>
		/// Gets variables of fornula
		/// </summary>
		/// <param name="formula">The formula</param>
		/// <param name="s">List of variables</param>
		static public void GetVariables(MathFormula formula, List<char> s)
		{
			for (int i = 0; i < formula.Count; i++)
			{
				MathSymbol sym = formula[i];
				if (sym.SymbolType == (byte)FormulaConstants.Variable)
				{
					char c = sym.Symbol;
					if ((c != 'e') & (c != '%'))
					{
						if (!s.Contains(c))
						{
							s.Add(c);
						}
					}
				}
				for (int j = 0; j < sym.Count; j++)
				{
					GetVariables(sym[j], s);
				}
			}
		}
		
		/// <summary>
		/// Gets variables of formula
		/// </summary>
		/// <param name="formula">The formula</param>
		/// <returns>String of variables</returns>
		static public string GetVariables(MathFormula formula)
		{
			List<char> s = new List<char>();
			GetVariables(formula, s);
			string str = "";
			foreach (char c in s)
			{
				str += c;
			}
			return str;
		}

		/// <summary>
		/// Gets variables of formulas
		/// </summary>
		/// <param name="formulas">The formulas</param>
		/// <returns>String of variables</returns>
		static public string GetVariables(MathFormula[] formulas)
		{
			List<char> s = new List<char>();
			string str = "";
			foreach (MathFormula formula in formulas)
			{
				GetVariables(formula, s);
			}
			foreach (char c in s)
			{
				str += c;
			}
			return str;
        }

        #endregion

    }
}
