using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using FormulaEditor.UI.UserControls;
using FormulaEditor;
using FormulaEditor.UI.Utils;
using FormulaEditor.Drawing;
using FormulaEditor.Drawing.Symbols;

namespace FormulaEditor.UI.Forms
{
    /// <summary>
    /// Editors of formulas
    /// </summary>
    public partial class FormulaEditorForm : Form
    {

        #region Fields

        private UserControlFormulaEditor panel;

        private bool accepted = false;

        private string s;

        private string[,] sub;

        private string[] symbols;


        private string formula;

        private List<string> additional;


        #endregion


        #region Ctor

        private FormulaEditorForm()
        {
            InitializeComponent();
            panel = userControlFormulaEditor;
        }

        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="s">Variables</param>
        /// <param name="sub">Subscripted symbols</param>
        /// <param name="symbols">Letter symbols</param>
        public FormulaEditorForm(string s, string[,] sub, string[] symbols)
            : this()
        {
            this.LoadControlResources();
            this.symbols = symbols;
            this.s = s;
            this.sub = sub;
            
        }

        #endregion

        #region Members

        #region Public

        /// <summary>
        /// String representation of formula
        /// </summary>
        public string Formula
        {
            get
            {
                return panel.Formula;
            }
            set
            {
                formula = value;
                panel.Formula = value;
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        public bool Test
        {
            set
            {
                if (value)
                {
                    buttonCancel.Visible = false;
                    buttonOK.Visible = false;
                    textBoxFormula.Visible = true;
                    buttonConvert.Visible = true;
                }
            }
        }

        /// <summary>
        /// Creates image from formula
        /// </summary>
        /// <param name="formula">Formula</param>
        /// <returns>Image</returns>
        public static Image CreateImage(string formula)
        {
            Image im = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(im);
            SimpleSymbolDrawable.Prepare(new int[] { 8, 6, 5, 4 }, g);
            MathFormulaDrawable f = new MathFormulaDrawable(MathFormula.FromString(new int[] { 8, 6, 5, 4 }, formula), DrawableConverter.Object);
            f.CalculateFullRelativeRectangle();
            Rectangle r = f.FullRelativeRectangle;
            Point p = new Point(10, -r.Y);
            f.Position = p;
            f.CalculatePositions();
            im = new Bitmap(r.Width + 20, r.Height);
            Brush brush = new SolidBrush(Color.White);
            g = Graphics.FromImage(im);
            g.FillRectangle(brush, 0, 0, im.Width, im.Height);
            f.Draw(g);
            SimpleSymbolDrawable.Prepare(MathSymbolFactory.Sizes, g);
            g.Dispose();
            return im;
        }

        /// <summary>
        /// The "is accepted" sign
        /// </summary>
        public bool Accepted
        {
            get
            {
                return accepted;
            }
        }

        #endregion

        #endregion

        #region Event handlers

        private void FormulaEditorForm_Load(object sender, EventArgs e)
        {
            panel.Prepare(s, 0, sub, symbols);
            panel.Formula = formula;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            /*           try
                       {
                           MathFormula formula = panel.Performer.Formula;
                       }
                       catch (System.Exception ex)
                       {
                           WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                       }*/
            accepted = true;
            Dispose();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }


        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, textBoxFormula.Text);
                Formula = f.FormulaString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}