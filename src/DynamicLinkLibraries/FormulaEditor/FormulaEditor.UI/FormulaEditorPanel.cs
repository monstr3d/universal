using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Resources;

using FormulaEditor;
using FormulaEditor.Drawing;
using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;
using FormulaEditor.Symbols;

namespace FormulaEditor.UI
{
	
	/// <summary>
	/// The Panel of editor
	/// </summary>
	public class FormulaEditorPanel : Panel
	{
		private FormulaEditor.FormulaEditorPerformer performer = null;

		private Control parent;

        /// <summary>
        /// Default constructor
        /// </summary>
		public FormulaEditorPanel()
		{
		}
 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="fon">Fon</param>
        /// <param name="symbols">Symbols</param>
		public FormulaEditorPanel(Control parent, Image[] fon, string[][] symbols)
		{
			//this.show = show;
			this.parent = parent;
		}

        /// <summary>
        /// Performer
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FormulaEditor.FormulaEditorPerformer Performer
		{
			set
			{
				performer = value;
			}
			get
			{
				return performer;
			}
		}



        /// <summary>
        /// Preparation
        /// </summary>
		public void Prepare()
		{
			Prepare("abcdfgxyzt", 4, null, null);
		}

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="sx">Variable symbols</param>
        /// <param name="n">Level</param>
        /// <param name="sSubscript">Subscripted symbols</param>
        /// <param name="symbols">Text symbols</param>
        public void Prepare(string sx, int n, string[,] sSubscript, string[] symbols)

		{
            string[] all =  symbols;

            Hashtable table = new Hashtable();
            string[,] el = new string[,] {{"=", "="}, {"&", "AND"}, {"\u2216", "AND"}, {"\u2217", "OR"}, {"|", "OR"}, {"\u8835", "=>"}, {"l", "LIKE"}, {"p", "=>"}, 
                       {"¬", "NOT"}, {"(", "("}, {".", "."}, {":", ":"},{"?", "?"}, {"<", "<"}, {">", ">"}, {"+", "+"},
                {"-", "-"}, {"*", "*"}, {"/", "/" }, {"﹪", "%" }, {"=", "="}, {"A", "atan2"}, {"'", "d/dt"}};
            for (int i = 0; i < el.GetLength(0); i++)
            {
                table[el[i, 0]] = el[i, 1];
            }
           // MathFormula.Resources = table;

             
			int[] sizes = MathSymbolFactory.Sizes;
			int sub = (sSubscript == null) ? 0 : sSubscript.GetLength(0);
			MathFormulaDrawable formula = new MathFormulaDrawable(new MathFormula((byte)0, sizes), DrawableConverter.Object);
			Control control = this;
			performer = new FormulaEditor.FormulaEditorPerformer(control, formula);
			Color[] cols = new Color[]{Color.FromArgb(216, 203, 187), Color.Black};
			performer.SetColors(cols[0], cols[1]);
			Graphics g = Graphics.FromHwnd(control.Handle);
			SimpleSymbolDrawable.Prepare(sizes, g);
			BracketsSymbolDrawable.Prepare(sizes, g);
            AbsSymbolDrawable.Prepare(sizes, g);
            if (all != null)
            {
                foreach (string str in all)
                {
                    foreach (char c in str)
                    {
                        performer.Add(new SimpleSymbolDrawable(
                            new SimpleSymbol(c, 0x0, false, false)));
                    }
                }
            }

			string ss = sx;
			for (int i = 0; i < sub; i++)
			{
				performer.Add(new SubscriptedSymbolDrawable(new SubscriptedSymbol(sSubscript[i, 0], sSubscript[i, 1])));
			}
			for (int i = 0; i < ss.Length; i++)
			{
				performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(ss[i])));
			}
            string elem = "scletqabjkfgw'\u2211\u03B4\u0442";
			for (int i = 0; i < elem.Length; i++)
			{
				performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(elem[i], false, (byte)4)));
			}
			string integerSym = "ABCDEFGH";
			performer.Add(new BinaryFunctionSymbolDrawable(new BinaryFunctionSymbol('A', "atan2")));
			for (int i = 0; i < integerSym.Length; i++)
			{
				char c = integerSym[i];
				performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(c, (byte)4, false, ElementaryIntegerOperation.GetString(c))));
			}
			string numbers = "x0123456789ABCDEF";
			for (int i = 0; i < numbers.Length; i++)
			{
				performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(numbers[i], false, (byte)5)));
			}
            string binary = ".+-*×=><\u2264\u2265\u2260?:&|^\u2266\u2267\u2216\u2217\u8835l\u2270";
            //string[,] el = new string[,] {{"\u2216", "AND"}, {"\u2217", "OR"}};
            //string binary = ".+-*=><?:&|^\u2217l";
            for (int i = 0; i < binary.Length; i++)
			{
				performer.Add(new BinarySymbolDrawable(new BinarySymbol(binary[i])));
			}
			string unary = "¬~";
			for (int i = 0; i < unary.Length; i++)
			{
				performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(unary[i], false, (byte)4)));
			}
			performer.Add(new BracketsSymbolDrawable(new BracketsSymbol()));
            performer.Add(new AbsSymbolDrawable(new AbsSymbol()));
            performer.Add(new RootSymbolDrawable(new RootSymbol()));
			performer.Add(new FractionSymbolDrawable(new FractionSymbol()));
			performer.Add(new BinarySymbolDrawable(MathSymbol.Bra as BinarySymbol));
			performer.Add(new SimpleSymbolDrawable(MathSymbol.Ket as SimpleSymbol));
			performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('e')));
			performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('%', (byte)FormulaConstants.Variable, true, "\u03c0")));
			for (int i = 0; i < n; i++)
			{
				performer.Add(new SeriesSymbolDrawable(new SeriesSymbol(i)));
			}
			int x = 10, y = 10;
			int bottom = 0;
			IDrawableSymbol symbol = null;
            int ns = 0;
            if (all != null)
            {
                foreach (string str in all)
                {
                    foreach (char c in str)
                    {

                        symbol = performer[ns];
                        Point p = new Point(x, y);
                        MathSymbolDrawable.SetComponentPosition(symbol, p);
                        symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth, (int)(1.5 * 20));
                        x += symbol.PureDrawable.RectForShow.Width;
                        ++ns;
                    }
                    bottom = y + symbol.PureDrawable.RectForShow.Height;
                    y = bottom;
                    x = 10;
                }
            }

			if (sub != 0)
			{
				for (int i = ns; i < sub + ns; i++)
				{
					symbol = performer[i];
					Point p = new Point(x, y);
					MathSymbolDrawable.SetComponentPosition(symbol, p);
					symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth, (int)(1.5 * 20));
					x += symbol.PureDrawable.RectForShow.Width;
				}

				bottom = y + symbol.PureDrawable.RectForShow.Height;
				y = bottom;
				x = 10;
			}
			for (int i = sub + ns; i < sub + ns + ss.Length; i++)
			{
				symbol = performer[i];
				Point p = new Point(x, y);
				MathSymbolDrawable.SetComponentPosition(symbol, p);
				symbol.PureDrawable.RectForShow = new Rectangle(x, y, 30, (int)(1.5 * 20));
				x += symbol.PureDrawable.RectForShow.Width;
			}

			bottom = y + symbol.PureDrawable.RectForShow.Height;
			y = bottom;
			x = 10;
			for (int i = ss.Length + ns + sub; i < ss.Length + elem.Length + 2 + sub + ns; i++)
			{
				symbol = performer[i];
				Point p = new Point(x, y);
				MathSymbolDrawable.SetComponentPosition(symbol, p);
				symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
				x += symbol.PureDrawable.RectForShow.Width;
			}
			bottom = y + symbol.PureDrawable.RectForShow.Height;
			y = bottom;
			x = 10;

			for (int i = sub + ns + ss.Length + elem.Length + 1 ; i < sub + ns + ss.Length + elem.Length + integerSym.Length + 1; i++)
			{
				symbol = performer[i];
				Point p = new Point(x, y);
				MathSymbolDrawable.SetComponentPosition(symbol, p);
				symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
				x += symbol.PureDrawable.RectForShow.Width;
			}

			bottom = y + symbol.PureDrawable.RectForShow.Height;
			y = bottom;
			x = 10;
			for (int i = sub + ns + ss.Length + elem.Length + integerSym.Length + 1; 
				i < sub + ns + ss.Length + elem.Length + numbers.Length + integerSym.Length + 2; i++)
			{
				symbol = performer[i];
				Point p = new Point(x, y);
				MathSymbolDrawable.SetComponentPosition(symbol, p);
				symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
				x += symbol.PureDrawable.RectForShow.Width;
			}
			bottom = y + symbol.PureDrawable.RectForShow.Height;
			y = bottom;
			x = 10;
			for (int i = sub + ns + ss.Length + elem.Length + integerSym.Length + numbers.Length + 1; i < sub + ns + ss.Length +
				elem.Length + numbers.Length + integerSym.Length + binary.Length + unary.Length + 8 + n; i++)
			{
				symbol = performer[i];
				Point p = new Point(x, y);
				MathSymbolDrawable.SetComponentPosition(symbol, p);
				symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
				x += symbol.PureDrawable.RectForShow.Width;
			}
			bottom = y + symbol.PureDrawable.RectForShow.Height;
			Rectangle r = new Rectangle(80, bottom, 1100, control.Height - bottom - 20);
			performer.FormulaRectangle = r;
			Image back = new Bitmap(1200, r.Y + r.Height + 10);
			back.SetControlResolution();
			g = Graphics.FromImage(back);
			PureDrawableSymbol.Graphics = Graphics.FromHwnd(this.Handle);
			g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, back.Width, back.Height);
			g.DrawRectangle(new Pen(Color.Black), 0, 0, back.Width - 1, back.Height - 1);
			Font f = new Font("Serif", sizes[0], FontStyle.Bold | FontStyle.Italic);
			int delta = 15;
			Brush bBrush = new SolidBrush(Color.Black);
			g.DrawString("f = ", f, bBrush, 10, r.Y + r.Height / 2 + delta);
			g.Dispose();
			performer.Prepare(back);
			formula = new MathFormulaDrawable(new MathFormula((byte)0, sizes), DrawableConverter.Object);
			performer.Formula = formula;
			performer.InitEventHandlers();
			performer.DrawFormula();
		}


	}

}
