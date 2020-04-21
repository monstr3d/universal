using System;
/*
using System.Drawing;
using System.Windows.Forms;
*/
using System.Collections;
//using CategoryTheory;


namespace FormulaEditor.Symbols
{
	/// <summary>
	/// Powered indexed symbol
	/// </summary>
	public class PoweredIndexedSymbol : IndexedSymbol
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		public PoweredIndexedSymbol(char c) : base(c, (byte)FormulaConstants.Powered, true)
		{
			s = "" + c;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		public PoweredIndexedSymbol(char c, byte type, bool italic) : base(c, type, italic)
		{

        }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="s">string representation</param>
		public PoweredIndexedSymbol(char c, byte type, bool italic, String s) : base(c, type, italic, s)
		{

        }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="type">the type</param>
		public PoweredIndexedSymbol(char c,  bool italic, byte type) : base(c, italic, type)
		{

        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
		{
			base.SetToFormula(formula);
			/*
			if (italic)
			{
				font = fontsItalic[level];
			}
			else
			{
				font = fonts[level];
			}
			widthInsert = (int)graphics.MeasureString("y", font, 100).Width;
			*/
			if (!GetType().Equals(typeof(PoweredIndexedSymbol)))
			{
				return;
			}
			if (level < (sizes.Length - 1))
			{
				MathFormula child = new MathFormula((byte)(level + 1), sizes);
				children.Add(child);
				//childPositions = new Point[]{new Point(), new Point()};
				return;
			}
			children = null;
		}



        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
		{
			return new PoweredIndexedSymbol(symbol, type, italic, s);
		}

		/// <summary>
		/// The associated object
		/// </summary>
		/*public object Object
		{
			get
			{
				return obj;
			}
			set
			{
				obj = value;
			}
		}*/

		public override int SubscriptIndex
		{
			get
			{
				MathFormula f = this[1];
				string s = "";
				for (int i = 0; i < f.Count; i++)
				{
					s += f[i].Symbol;
				}
				return Int32.Parse(s);
			}
		}

        /// <summary>
        /// Degree
        /// </summary>
		public int Deg
		{
			get
			{
				MathFormula f = this[0];
				if (f.Count == 0)
				{
					return 1;
				}
				string s = "";
				for (int i = 0; i < f.Count; i++)
				{
					s += f[i].Symbol;
				}
				return Int32.Parse(s);
			}
		}
		
		
/*
		/// <summary>
		/// Arity of this operation
		/// </summary>
		public int Arity
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Return type
		/// </summary>
		public object ReturnType
		{
			get
			{
				return obj;
			}
		}
*/
		/// <summary>
		/// The "is powered" sign
		/// </summary>
		public override bool IsPowered
		{
			get
			{
				return false;
			}
		}


	}
}
