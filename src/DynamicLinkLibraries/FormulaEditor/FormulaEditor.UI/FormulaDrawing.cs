using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


using FormulaEditor;
using FormulaEditor.Drawing;

namespace FormulaEditor.UI
{
    class FormulaDrawing
    {
        MathFormulaDrawable formula;
        Point point = new Point();

        private Pen rectPen = new Pen(Color.Black);
        private Brush fillBrush = new SolidBrush(Color.FromArgb(216, 203, 187));

        #region IFormulaDrawing Members

        public void Set(string formula, System.Drawing.Point point)
        {
            this.point.X = point.X;
            this.point.Y = point.Y;
            this.formula = new MathFormulaDrawable(MathFormula.FromString(MathSymbolFactory.Sizes, formula), DrawableConverter.Object);
            this.formula.Position = point;
			this.formula.CalculateFullRelativeRectangle();
		    this.formula.CalculatePositions();

        }

        public void Paint(System.Drawing.Graphics g, int x, int y, int width, int height)
        {
			g.FillRectangle(fillBrush, x, y, width, height);
			if (formula != null)
			{
				formula.Draw(g);
			}
			g.DrawRectangle(rectPen, x, y, width - 1, height - 1);
        }

        #endregion
}
}
