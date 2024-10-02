using System;

using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary string converter for formula
    /// </summary>
	public class ElementaryFormulaStringConverter : MathFormulaStringConverter
	{
		/// <summary>
		/// Singleton
		/// </summary>
		static public readonly ElementaryFormulaStringConverter Object 
            = new ElementaryFormulaStringConverter();
		
        /// <summary>
        /// Default constructor
        /// </summary>
        protected ElementaryFormulaStringConverter()
		{
		}


        /// <summary>
        /// Chooses symbol from string
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="b">The begin position</param>
        /// <param name="e">The end position</param>
        /// <returns>The chosen symbol</returns>
        public override MathSymbol ChooseSymbol(string str, int b, int e)
		{
			char c = str[b];
			char by = str[b + 1];
			char cb = (char)by;
            if ((c == '\u2221') & (by == '|'))
            {
                string s1 = "";
                int ii = b + 2;
                for (; ii < str.Length; ii++)
                {
                    if (str[ii] == '|')
                    {
                        break;
                    }
                    s1 += str[ii];
                }
                ++ii;
                return new FieldSymbol(s1);
            }
            if ((c == '\u2220') & (by == '|'))
			{
				string s1 = "";
				int ii = b + 2;
				for (; ii < str.Length; ii++)
				{
					if (str[ii] == '|')
					{
						break;
					}
					s1 += str[ii];
				}
				++ii;
				string s2 = "";
				for (; ii < str.Length; ii++)
				{
					if (str[ii] == '|')
					{
						break;
					}
					s2 += str[ii];
				}
				return new SubscriptedSymbol(s1, s2);
			}
			switch (by)
			{
                case '0':
                    {
                        return new SimpleSymbol(c, 0x0, false, false);
                    }
                case '1':
					if (c == '%')
					{
						return new SimpleSymbol('%', (byte)FormulaConstants.Variable, true, "\u03c0");
						//break;
					}
					return new SimpleSymbol(c);
					//break;
				case '2':
					if (c == 'P')
					{
						return new BracketsSymbol();
					}
					else if (c == 'F')
					{
						return new FractionSymbol();
					}
					else if (c == 'A')
					{
						return new BinaryFunctionSymbol('A', "atan2");
					}
					else if (c == 'Q')
					{
						return new RootSymbol();
					}
					else if (c == 'A')
					{
						return new BinaryFunctionSymbol('A', "atan2");
					}
					break;
				case '3':
					string ss = "";
					ss += c;
					if (c == (byte)'*')
					{
						ss = "\u2219";
					}
					if (c == '\u2266')
					{
						ss = "<<";
					}
					if (c == '\u2267')
					{
						ss = ">>";
					}
					if (c == '\u2216')
					{
						ss = "AND";
					}
					if (c == '\u8835')
					{
						ss = "=>";
					}
					if (c == '\u2217')
					{
						ss = "OR";
					}
                    if (108 == (byte)c)
                    {
                        ss = "LIKE";
                    }
                    if (c == '%')
                    {
                        ss = "%";
                    }
					b += 2;
					return new BinarySymbol(c, false, ss);
					//break;
				case '4':
					string comp = c + "";
					if (!comp.Equals(comp.ToLower()))
					{
						return new SimpleSymbol(c, (byte)FormulaConstants.Unary, false, ElementaryIntegerOperation.GetString(c));
					}
					return new SimpleSymbol(c, false, (byte)FormulaConstants.Unary);
				case '5':
					return new SimpleSymbol(c, false, (byte)FormulaConstants.Number);
					//break;
				case '7':
					return new SeriesSymbol(Int32.Parse(c + ""));
					//break;
				case '8':
					return new IndexedSymbol(c);
				case '9':
					return new PoweredIndexedSymbol(c);
			}
			return null;
		}

        /// <summary>
        /// Converts symbol to string
        /// </summary>
        /// <param name="symbol">The sybmol</param>
        /// <returns>Conversion result</returns>
		public override string Convert(MathSymbol symbol)
		{

			string str = "";
			if (symbol is SubscriptedSymbol)
			{
				SubscriptedSymbol sym = symbol as SubscriptedSymbol;
				StringPair p = sym.Pair;
				str = "\u2220|" + p.First + "|" + p.Second + "|";
			}
            else if (symbol is FieldSymbol)
            {
                FieldSymbol sym = symbol as FieldSymbol;
                str = "\u2221|" + sym.String + "|";
            }
            else
            {
                if (symbol.SymbolType == (int)FormulaConstants.Series)
                {
                    string s = symbol.Index + "";
                    str += s;
                }
                else
                {
                    str += symbol.Symbol;
                }
                Int32 t = symbol.SymbolType;
                char b = (t.ToString()[0]);
                str += b;
            }
			if (symbol.Count > 0)
			{
				for (int i = 0; i < symbol.Count; i++)
				{
					string vec = Convert(symbol[i]);
					str += "" + Separator + "" + BeginSeparator + vec + Separator + "" + EndSeparator; 
				}
			}
			return str;
		}

	}
}