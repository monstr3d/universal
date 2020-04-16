using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration.Assemblies;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Xml;


using CategoryTheory;
using Diagram.UI;
using FormulaEditor;
using FormulaEditor.UI;
using FormulaEditor.UI.Forms;
using FormulaEditor.Drawing;

namespace DataPerformer.UI
{
    /// <summary>
    /// Panel which draws formula
    /// </summary>
	public class PanelFormula : Panel
	{
		private char var;
		private Control control;
		private Button button;
		private string formulaString;
		private MathFormulaDrawable formula;
		private Rectangle formulaRect;
		private Image bkgnd;
		private Pen linePen = new Pen(Color.Black);
		private Brush bkBrush = new SolidBrush(Color.Gray);
		private Brush rBrush = new SolidBrush(Color.FromArgb(216, 203, 187));
		private Brush blackBrush = new SolidBrush(Color.Black);
		private Font font = new Font("Times", MathSymbolFactory.Sizes[0], FontStyle.Bold | FontStyle.Italic);
		private Point pointFormula;
		private string variables;
		//		private string cap;
		private string[,] sub;
        private string[] symbols;
        private static string[] staticSymbols;
        private int left;
        private string cap;
        private bool deriv;
        private int center;
        private int shift;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cap">Caption</param>
        /// <param name="control">Control</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="variables">Variable</param>
        /// <param name="deriv">The "dertivation" sign</param>
        /// <param name="sub">Subscripted symbols</param>
        /// <param name="symbols">Symbols</param>
        /// <param name="additional">Symbols</param>
		public PanelFormula(string cap, Control control, int width, int height, string variables, 
			bool deriv, string[,] sub, string[] symbols, List<string> additional = null)
		{
            if (symbols == null)
            {
                this.symbols = staticSymbols;
            }
            else
            {
                if (symbols[0] != null)
                {
                    this.symbols = symbols;
                }
            }
			this.var = cap[0];
			this.sub = sub;
            this.cap = cap;
            this.deriv = deriv;
			this.control = control;
			this.variables = variables;
			Width = width;
			Height = height;
            center = height / 2;
            shift = -10;
            button = new Button();
            button.Width = 150;
            button.Text = ResourceService.Resources.GetControlResource("Edit", Utils.ControlUtilites.Resources);
            button.Left = 20;
            button.Top = center - button.Height / 2;
            Controls.Add(button);
            button.Click += new EventHandler(onClick);

            setBkgnd();
			Paint += new PaintEventHandler(onPaint);
 			formulaRect = new Rectangle(left, 5, width - left - 5, height - 10);
			center = formulaRect.Top + formulaRect.Height / 2;
			pointFormula = new Point(left + 30, center);
		}

        private void setBkgnd()
        {
            bkgnd = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bkgnd);
            left = button.Left + button.Width + 30;
            g.FillRectangle(bkBrush, 0, 0, Width, Height);
            g.DrawRectangle(linePen, 0, 0, Width - 1, Height - 1);
            g.DrawString(cap + " =", font, blackBrush, left, center + shift);
            if (deriv)
            {
                g.DrawString(".", font, blackBrush, left, center + shift - font.Height - 3);
            }
            int w = (int)g.MeasureString(cap, font).Width;
            left += 60 + w;
            formulaRect = new Rectangle(left, 5, Width - left - 5, Height - 10);
            Formula = formulaString;

        }


        /// <summary>
        /// Edited variable
        /// </summary>
		public char Variable
		{
			get
			{
				return var;
			}
		}

        /// <summary>
        /// Edited formula
        /// </summary>
		public string Formula
		{
			get
			{
				return formulaString;
			}
			set
			{
				if (value == null)
				{
					return;
				}
				formulaString = value;
				formula = new MathFormulaDrawable(MathFormula.FromString(MathSymbolFactory.Sizes, value), DrawableConverter.Object);
				formula.Position = pointFormula;
				formula.CalculateFullRelativeRectangle();
				formula.CalculatePositions();
				Graphics g = Graphics.FromImage(bkgnd);
				g.FillRectangle(rBrush, formulaRect.Left, formulaRect.Top, formulaRect.Width, formulaRect.Height);
				g.DrawRectangle(linePen, formulaRect.Left, formulaRect.Top, formulaRect.Width, formulaRect.Height);
				formula.Draw(g);
			}
		}

        /// <summary>
        /// Symbols
        /// </summary>
        public static string[] Symbols
        {
            set
            {
                staticSymbols = value;
            }
        }

      

        private static void control_Resize(object sender, EventArgs args)
        {
            Control cont = sender as Control;
            foreach (Control c in cont.Controls)
            {
                c.Width = cont.Width - 40;
                if (c is PanelFormula)
                {
                    PanelFormula p = c as PanelFormula;
                    p.setBkgnd();
                }
                c.Refresh();
            }
        }

        /// <summary>
        /// Sets resize operation for control
        /// </summary>
        /// <param name="control">The control</param>
        public static void SetResize(Control control)
        {
            control.Resize += new EventHandler(control_Resize);
        }



		private void onPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(bkgnd, 0, 0, bkgnd.Width, bkgnd.Height);
		}

		private void onClick(object sender, System.EventArgs e)
		{
			FormulaEditorForm f = new FormulaEditorForm(variables, sub, symbols);
			if (formulaString != null)
			{
				f.Formula = formulaString;
			}
			Form form = null;
			Control c = this;
			while (true)
			{
				if (c is Form)
				{
					form = c as Form;
					break;
				}
				c = c.Parent;
			}
			f.ShowDialog(form);
			if (!f.Accepted)
			{
				return;
			}
			Formula = f.Formula;
			Refresh();
		}

	}

}
