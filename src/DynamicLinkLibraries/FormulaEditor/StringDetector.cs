using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
	/// <summary>
	/// Unbold string detector
	/// </summary>
	public class StringDetector : IOperationDetector
	{
		
		#region Fields
		byte type;
		bool bold;
		bool italic;
		#endregion

		#region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">String type</param>
        /// <param name="bold">The "bold" sign</param>
        /// <param name="italic">The "italic" sign</param>
		public StringDetector(byte type, bool bold, bool italic)
		{
			this.type = type;
			this.bold = bold;
			this.italic = italic;
		}

		#endregion
		
		#region IOperationDetector Members

        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="s">First symbol of the formula</param>
        /// <returns>Acceptor of operation</returns>
        public IOperationAcceptor Detect(MathSymbol s)
		{
			if (s is SimpleSymbol)
			{
				SimpleSymbol sym = s as SimpleSymbol;
				if ((sym.Bold == bold) & (sym.Italic == italic) & (sym.SymbolType == type))
				{
					return new StringOperationAcceptor(s.String);
				}
			}
			return null;
		}

		#endregion

		#region Specific Members

        /// <summary>
        /// Converts math formula
        /// </summary>
        /// <param name="formula">Initial formula</param>
        /// <returns>Conversion result</returns>
		public MathFormula Convert(MathFormula formula)
		{
            MathFormula form = formula.Copy();
            for (int i = 0; i < form.Count; i++)
            {
                List<MathFormula> ch = form[i].Children;
                if (ch == null)
                {
                    break;
                }
                List<MathFormula> nch = new List<MathFormula>();
                foreach (MathFormula ff in ch)
                {
                    MathFormula fch = Convert(ff);
                    if (fch == null)
                    {
                        break;
                    }
                    nch.Add(fch);
                }
                if (nch.Count > 0)
                {
                    form[i].Children = nch;
                }
            }
			MathFormula f = new MathFormula(0x0, form.Sizes);
			SimpleSymbol sym = null;
			MathSymbol symbol = form.First;
            if (symbol == null)
            {
                return null;
            }
            MathSymbol next;
			while (true)
			{
                next = symbol.Next;
				if (symbol is SimpleSymbol & !(symbol is FieldSymbol) & !(symbol is BinarySymbol)
                    & !(symbol is FractionSymbol) & !(symbol is BracketsSymbol) & !(symbol is RootSymbol) &
                        !(symbol is SeriesSymbol) & !(symbol is SubscriptedSymbol) & !(symbol is IndexedSymbol)
                    & !(symbol is PoweredIndexedSymbol))
				{
					SimpleSymbol ss = symbol as SimpleSymbol;
					if ((ss.Bold == bold) & (ss.Italic == italic) & (ss.SymbolType == type) 
                        & (ss.String.Length <= 1))
					{
						if (sym == null)
						{
							sym = ss.Clone() as SimpleSymbol;
						}
						else
						{
							string str = sym.String + ss.String;
							sym = new SimpleSymbol(sym.Symbol, type, italic, bold, str);
						}
					}
					else
					{
						if (sym != null)
						{
							sym.AppendWithChildren(f);
							sym = null;
						}
						symbol.AppendWithChildren(f);
					}
				}
				else
				{
					if (sym != null)
					{
						sym.AppendWithChildren(f);
						sym = null;
					}
					symbol.AppendWithChildren(f);
				}
				symbol = next;
				if (symbol == null)
				{
					if (sym != null)
					{
						sym.AppendWithChildren(f);
					}
					break;
				}
			}
 			return f;
		}
		#endregion
	}
}
