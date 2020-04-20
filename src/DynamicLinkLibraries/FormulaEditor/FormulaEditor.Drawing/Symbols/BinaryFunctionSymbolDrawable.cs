using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;

using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{
    public class BinaryFunctionSymbolDrawable : BinaryFunctionSymbol, IDrawableSymbol
    {


        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();
        private int down, h, updown, warc;

        public BinaryFunctionSymbolDrawable(BinaryFunctionSymbol symbol)
            : base(symbol.Symbol, symbol.String)
        {
        }

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BinaryFunctionSymbolDrawable(this);
        }
        #region IDrawableSymbol Members

        /// <summary>
        /// Sets location on toolbar
        /// </summary>
        /// <param name="x">the x position</param>
        /// <param name="y">the y position</param>
        /*public void SetLocationOnTable(int x, int y)
        {
            pDrawable.RectForShow.Location = new Point(x, y);
        }*/


        public void CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
            IDrawableSymbol ds = this;
            PureDrawableSymbol pDrawable = ds.PureDrawable;
            pDrawable.InsertedRectX = pDrawable.Rectangle.X;
            pDrawable.InsertedRectY = pDrawable.Rectangle.Y;
            pDrawable.InsertedRectHeight = pDrawable.Rectangle.Height;
            pDrawable.InsertedRectWidth = pDrawable.WidthInsert;
            pDrawable.InsertedRectX = pDrawable.InsertedRect.X - pDrawable.WidthInsert / 2;
        }


        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        public override void SetToFormula(MathFormula formula)
        {
            sizes = formula.Sizes;
            level = formula.Level;
            pDrawable.Font = PureDrawableSymbol.Fonts[level];
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            pDrawable.SetToFormula(formula);
            for (int i = 0; i < 2; i++)
            {
                children.Add(
                    new MathFormulaDrawable(new MathFormula((byte)level, sizes), DrawableConverter.Object));
            }

            pDrawable.ChildPositions = new Point[] { new Point(), new Point() };
        }

        /// <summary>
        /// Calculates relative rectangle with children
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {

            MathSymbolDrawable.CalculateFullRelativeRectangle(this);
            CalculateRelativeRectangle();
            Rectangle rr = pDrawable.RelativeRectangle;
            int w = rr.Width;
            int up = rr.Y;
            MathFormulaDrawable[] f = new MathFormulaDrawable[]{
																   this[0] as MathFormulaDrawable,
																   this[1] as MathFormulaDrawable};
            Rectangle r1 = f[0].FullRelativeRectangle;
            Rectangle r2 = f[1].FullRelativeRectangle;
            up = (r1.Y < r2.Y) ? r1.Y : r2.Y;
            if (rr.Y < up)
            {
                up = rr.Y;
            }
            int a1 = Math.Abs(r1.Y);
            int a2 = r1.Height + r1.Y;
            down = (a1 > a2) ? a1 : a2;
            if (rr.Y < up)
            {
                up = rr.Y;
            }
            int wc = (int)PureDrawableSymbol.Graphics.MeasureString(" , ", PureDrawableSymbol.FontsBold[level]).Width;
            h = (int)((double)down / Math.Sin(40.0 * 3.1415926 / 180.0));
            warc = (int)((double)h * (1 - Math.Cos(40.0 * 3.1415926 / 180.0)));
            int wpow = 0, hpow = 0;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -down - hpow;
            pDrawable.FullRelativeRectangleWidth = rr.Width + r1.Width + r2.Width + 6 * warc + 4 + wpow;
            pDrawable.FullRelativeRectangleHeight = 2 * down + hpow;
        }

        public int StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            }
        }

        /// <summary>
        /// Draws itself on desktop
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="brush">Drawing brush</param>
        /// <param name="pen">Drawing pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = PureDrawableSymbol.FontsBold[0];
            g.DrawString(s, f, PureDrawableSymbol.SymbolBrush, pDrawable.RectForShow.X, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            string str = s;
            if (s.Equals("(,)"))
            {
                str = "";
            }
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            g.DrawString(str, pDrawable.Font, PureDrawableSymbol.SymbolBrush,
                pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2) * g.MeasureString(str, pDrawable.Font).Width), y);
            int x = pDrawable.Position.X + (int)g.MeasureString(str, pDrawable.Font).Width;
            warc = (int)((double)h * (1 - Math.Cos(40.0 * Math.PI / 180.0)));
            MathFormulaDrawable f0 = this[0] as MathFormulaDrawable;
            int wc = (int)g.MeasureString(" , ", pDrawable.Font).Width;
            g.DrawString(" , ", pDrawable.Font, PureDrawableSymbol.SymbolBrush, x + warc + f0.FullRelativeRectangle.Width, y);
            int ww = 0;
            for (int i = 0; i < Count; i++)
            {
                MathFormulaDrawable f = this[i] as MathFormulaDrawable;
                if (f != null)
                {
                    ww += (int)f.FullRelativeRectangle.Width;
                }
            }
            g.DrawArc(PureDrawableSymbol.LinePen, x + 2, y - 2 * h, 4 * h, 4 * h, 140, 80);
            g.DrawArc(PureDrawableSymbol.LinePen, x + 2 + 2 * warc + ww + wc - 4 * h, y - 2 * h, 4 * h, 4 * h, -40, 80);
        }

        /// <summary>
        /// Calculates relative rectangle wihout children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            string str = s;
            if (str.Equals("(,)"))
            {
                str = "";
            }
           Font f = PureDrawableSymbol.FontsBold[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)PureDrawableSymbol.Graphics.MeasureString(str, f).Width;
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -h / 2;
            pDrawable.RelativeRectangleWidth = w;
            pDrawable.RelativeRectangleHeight = h;
            int dd = 0;
            if (children != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i] != null)
                    {
                        MathFormulaDrawable df = this[i] as MathFormulaDrawable;
                        Rectangle r = df.FullRelativeRectangle;
                        int a1 = Math.Abs(r.Y);
                        int a2 = r.Height + r.Y;
                        down = (a1 > a2) ? a1 : a2;
                        if (dd < Math.Abs(down))
                        {
                            dd = Math.Abs(down);
                        }
                        updown = down;
                    }
                }
            }
            down = dd;
            updown = dd;

        }

        /// <summary>
        /// Calculates positions of child formulas
        /// </summary>
        public void CalculateChildPositions()
        {
            Point[] p = new Point[] { GetChildPosition(0), GetChildPosition(1) };
            pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            MathFormulaDrawable[] f = {this[0] as MathFormulaDrawable,
										  this[1] as MathFormulaDrawable};
            Rectangle[] r = new Rectangle[] { f[0].FullRelativeRectangle, f[1].FullRelativeRectangle };
            warc = (int)(h * (1 - Math.Cos(40.0 * Math.PI / 180.0)));
            MathFormula child = this[0];
            int dx = 2 + warc;
            string str = s;
            if (s.Equals("(,)"))
            {
                str = "";
            }
            int x = pDrawable.Position.X + dx + (int)PureDrawableSymbol.Graphics.MeasureString(str, pDrawable.Font).Width;
            for (int i = 0; i < 2; i++)
            {
                p[i].X = x;
                p[i].Y = pDrawable.Position.Y;
                MathFormulaDrawable dr = this[i] as MathFormulaDrawable;
                x += (int)PureDrawableSymbol.Graphics.MeasureString(" , ", pDrawable.Font).Width + dr.FullRelativeRectangle.Width;
                pDrawable.ChildPositions[i].X = p[i].X;
                pDrawable.ChildPositions[i].Y = p[i].Y;
            }
        }

        /// <summary>
        /// Prepares itself
        /// </summary>
        /// <param name="performer">Editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
        {
            Font f = PureDrawableSymbol.FontsBold[0];
            pDrawable.Font = f;
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * pDrawable.Font.Height);
            int w = (int)g.MeasureString(s + "i", pDrawable.Font).Width;
            g.Dispose();
            Bitmap im = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(im);
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            gr.FillRectangle(brush, 1, 1, w - 2, h - 2);
            gr.DrawRectangle(pen, 0, 0, w - 1, h - 1);
            gr.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, gr.MeasureString("i", pDrawable.Font).Width / 2, PureDrawableSymbol.TOP_SHIFT);
            gr.Dispose();
            im.MakeTransparent(Color.White);
            pDrawable.SetImage(im);
        }

        public void CalculateRectangleForShow()
        {
        }

        public Point GetChildPosition(int n)
        {
            return MathSymbolDrawable.GetChildPosition(this, n);
        }


        #endregion



        #region IDrawableSymbol Members


        public PureDrawableSymbol PureDrawable
        {
            get { return pDrawable; }
        }

        #endregion
    }
}
