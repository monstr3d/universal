using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{
    public class DateTimeSymbolDrawable : DateTimeSymbol, IDrawableSymbol
    {

        #region Fields
        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        #endregion

        #region Constructors

        public DateTimeSymbolDrawable(DateTimeSymbol sym)
            : base(sym)
        {
        }

        #endregion

        #region Overriden Members

        public override object Clone()
        {
            return new DateTimeSymbolDrawable(this);
        }


        public override void SetToFormula(MathFormula formula)
        {
            pDrawable.SetToFormula(formula);
            level = formula.Level;
            sizes = formula.Sizes;
            pDrawable.Font = PureDrawableSymbol.FontsItalic[level];
        }


        #endregion

        #region IDrawableSymbol Members

        void IDrawableSymbol.CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
        }

        void IDrawableSymbol.CalculateFullRelativeRectangle()
        {
            IDrawableSymbol ds = this;
            ds.CalculateRelativeRectangle();
        }

        int IDrawableSymbol.StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)(g.MeasureString(s + "W", PureDrawableSymbol.FontsBold[0]).Width);
            }
        }

        void IDrawableSymbol.DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = (int)(pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2 - g.MeasureString(s, f).Width / 2);
            int width = (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            g.DrawString(s, f, brush, x, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        void IDrawableSymbol.DrawSelf(Graphics g)
        {
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            int width = (int)g.MeasureString(s, pDrawable.Font).Width;
            int x = pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2)) * width;
            g.DrawString(this + "", pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, y);
        }

        void IDrawableSymbol.CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)(PureDrawableSymbol.Graphics.MeasureString(this + "", f).Width);
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -h / 2;
            pDrawable.RelativeRectangleWidth = w;
            pDrawable.RelativeRectangleHeight = h;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -h / 2;
            pDrawable.FullRelativeRectangleWidth = w;
            pDrawable.FullRelativeRectangleHeight = h;
        }

        void IDrawableSymbol.CalculateChildPositions()
        {
        }

        void IDrawableSymbol.Prepare(FormulaEditorPerformer performer)
        {
            Font f;
            if (italic)
            {
                f = PureDrawableSymbol.FontsItalic[0];
            }
            else
            {
                f = PureDrawableSymbol.FontsBold[0];
            }
            pDrawable.Font = f;
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * pDrawable.Font.Height);
            int w = (int)g.MeasureString(s + "iw", pDrawable.Font).Width;
            int w1 = (int)g.MeasureString(s, pDrawable.Font).Width;
            g.Dispose();
            Bitmap im = new Bitmap(w, h);
            pDrawable.SetImage(im);
            Graphics gr = Graphics.FromImage(im);
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            gr.FillRectangle(brush, 1, 1, w - 2, h - 2);
            gr.DrawRectangle(pen, 0, 0, w - 1, h - 1);
            int x = (int)gr.MeasureString("i", pDrawable.Font).Width / 2;
            gr.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, PureDrawableSymbol.TOP_SHIFT);
            gr.Dispose();
            im.MakeTransparent(Color.White);
        }

        void IDrawableSymbol.CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Wiw" + s, PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
        }

        PureDrawableSymbol IDrawableSymbol.PureDrawable
        {
            get { return pDrawable; }
        }

        #endregion

        #region IInsertedObject Members

        System.Drawing.Rectangle IInsertedObject.InsertedRect
        {
            get { return pDrawable.InsertedRect; }
        }

        #endregion
    }
}
