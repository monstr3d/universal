using System;
using System.Collections.Generic;

using FormulaEditor.Symbols;

namespace FormulaEditor
{
	/// <summary>
	/// The factory for loading and saving formulas
	/// </summary>
	public class MathSymbolFactory 
	{


		private static int[] sizes;

		/// <summary>
		/// Begin separator of child
		/// </summary>
		static readonly public byte BEGIN_SEPARATOR = (byte)'[';

		/// <summary>
		/// End separator of child
		/// </summary>
		static readonly public byte END_SEPARATOR = (byte)']';

		/// <summary>
		/// Shift between symbol and separator 
		/// </summary>
		static readonly public byte SHIFT = 2;

		/// <summary>
		/// Gets position of next symbol
		/// </summary>
		/// <param name="v">v the string vector</param>
		/// <param name="n">n the current symbol position</param>
		/// <returns>position of next symbol</returns>
		public static int Next(List<byte[]> v, int n)
		{
			int s = v.Count;
			if (n >= s - 1)
			{
				return -1;
			}
			if (n + SHIFT >= (s - 1))
			{
				return  -1;
			}
			byte[] b = v[n + 1];
			if (GetByte(v, n + SHIFT) != BEGIN_SEPARATOR)
			{
				return n + SHIFT;
			}
			int m = 1;
			for (int i = n + SHIFT + 1; i < s; i++)
			{
				if (GetByte(v, i) == BEGIN_SEPARATOR)
				{
					m++;
				}
				else if (GetByte(v, i) == END_SEPARATOR)
				{
					m--;
				}
				if (m == 0)
				{
					if(i < s - 1)
					{
						if (GetByte(v, i + 1) == BEGIN_SEPARATOR)
						{
							continue;
						}
					}
					if ((i + 1) == (s - 1))
					{
						return -1;
					}
					else
					{
						return i + 1;
					}
				}
				if ((i + 1) == (s - 1))
				{
					return -1;
				}
			}
			return -1;
		}

		/// <summary>
		/// Sizes
		/// </summary>
		public static int[] Sizes
		{
			get
			{
				return sizes;
			}
			set
			{
				sizes = value;
			}
		}

		/// <summary>
		/// Gets byte from string vector
		/// </summary>
		/// <param name="v">The vector</param>
		/// <param name="i">The position</param>
		/// <returns>The byte</returns>
		public static byte GetByte(List<byte[]> v, int i)
		{
			return v[i][0];
		}

		/// <summary>
		/// Adds byte to string vector
		/// </summary>
		/// <param name="v">The vector</param>
		/// <param name="b">The byte</param>
		public static void AddByte(List<byte[]> v, byte b)
		{
			v.Add(new byte[]{b});
		}

		/// <summary>
		/// Creates symbol from string vector and sets it to formula
		/// </summary>
		/// <param name="f">the formula to set</param>
		/// <param name="v">the string vector</param>
		/// <param name="b">the begin position of symbol on string vector</param>
		/// <param name="e">the end position of symbol on string vector</param>
		/// <returns>The symbol</returns>
		public static MathSymbol CreateSymbol(MathFormula f, List<byte[]> v, int b, int e)
		{
			char c = (char)GetByte(v, b);
			byte by = GetByte(v, b + 1);
			char cb = (char)by;
			MathSymbol s = null;
			switch (by)
			{
				case (byte)'1':
					if (c == '%')
					{
						s = new SimpleSymbol('%', (byte)FormulaConstants.Variable, true, "\u03c0");
						break;
					}
					s = new SimpleSymbol(c);
					break;
				case (byte)'2':
					if (c == 'P')
					{
						s = new BracketsSymbol();
					}
					else if (c == 'F')
					{
						s = new FractionSymbol();
					}
					else if (c == 'A')
					{
						s = new BinaryFunctionSymbol('A', "atan2");
					}
                    else if (c == 'M')
                    {
                        return new AbsSymbol();
                    }
                    else
                    {
                        s = new RootSymbol();
                    }
					break;
				case (byte)'3':
					string ss = "";
					ss += c;
					if (c == (byte)'*')
					{
						ss = "\u2219";
					}
					s = new BinarySymbol(c, false, ss);
					break;
				case (byte)'4':
					s = new SimpleSymbol(c, false, (byte)FormulaConstants.Unary);
					break;
				case (byte)'5':
					s = new SimpleSymbol(c, false, (byte)FormulaConstants.Number);
					break;
				case (byte)'7':
					s = new SeriesSymbol(Int32.Parse(c + ""));
					break;
			}
			s.Append(f);
			MathSymbol symb = f.Last;
			int j = b + SHIFT;
			if (symb.Count > 0)
			{
				for (int i = 0; i < symb.Count; i++)
				{
					int m = 0;
					for(int k = j; /*k <= e*/; k++)
					{
						byte bt = GetByte(v, k);
						if (bt == BEGIN_SEPARATOR)
						{
							m++;
						}
						else if (bt == END_SEPARATOR)
						{
							m--;
						}
						if (m == 0)
						{
							if (symb[i] != null)
							{
								MathFormula formula = new MathFormula(symb[i].Level,
									f.Sizes, v, j + 1, k - 1);
								symb[i] = formula;
								j = k + 1;
								break;
							}
						}
					}
				}
			}
			return symb;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public MathSymbolFactory()
		{
		}
	}



}
