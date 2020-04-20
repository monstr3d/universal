using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{
    public class BinarySymbolDrawable : BinarySymbol, IDrawableSymbol
    {

        PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        public BinarySymbolDrawable(BinarySymbol symbol)
            : base(symbol.Symbol, symbol.Italic, symbol.String)
        {
        }

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BinarySymbolDrawable(this);
        }

        public static void DrawHelp(Graphics g, int x, int y, int w, int h, char c)
        {
            double coeff = 0.9;
            int left = (int)((1 - coeff) * w) + x;
            int right = (int)(coeff * w) + x;
            int middle = (int)(w / 2) + x;
            int top = +(int)((1 - coeff) * h) + y;
            int bottom = (int)(coeff * h) + y;
            int size = (w < h) ? w : h;
            int xx = x + w / 2;
            int yy = y;// +h / 2;
            if (c == '\u2216')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, left, bottom, middle, top);
                g.DrawLine(PureDrawableSymbol.WidePen, middle, top, right, bottom);
            }
            if (c == '\u2217')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, left, top, middle, bottom);
                g.DrawLine(PureDrawableSymbol.WidePen, middle, bottom, right, top);
            }
            if (c == '\u8835')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, left, top, middle, bottom);
                g.DrawLine(PureDrawableSymbol.WidePen, middle, bottom, right, top);
            }
            if (c == '\u2295')
            {
                DrawCircledPlus(g, PureDrawableSymbol.LinePen, xx, yy, size);
            }
            if (c == '\u2297')
            {
                DrawCircledProduct(g, PureDrawableSymbol.LinePen, xx, yy, size);
            }

        }


        #region IDrawableSymbol Members






        public void CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
        }

        /// <summary>
        /// Calculates rectangle for showing on desktop
        /// </summary>
        public void CalculateRectangleForShow()
        {
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
            SimpleSymbolDrawable.SetToFormula(this, formula);
        }

        public void CalculateFullRelativeRectangle()
        {
            if (GetType().Equals(typeof(BracketsSymbol)) | GetType().Equals(typeof(BracketsSymbolDrawable)))
            {
                return;
            }
            CalculateRelativeRectangle();
            Rectangle rr = pDrawable.RelativeRectangle;
            int w = rr.Width;
            int up = rr.Y;
            int delta = 0;
            if (children != null)
            {
                if (this[0].Count != 0)
                {
                    MathFormulaDrawable dr = this[0] as MathFormulaDrawable;
                    Rectangle r = dr.FullRelativeRectangle;
                    w += r.Width;
                    delta = rr.Height / 2 - r.Height;
                    up = rr.Y + delta;
                }
            }
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = up;
            pDrawable.FullRelativeRectangleWidth = w;
            pDrawable.FullRelativeRectangleHeight = rr.Height - delta;
        }

        public int StandardWidth
        {
            get
            {
                string ss = s + "";
                if (ss == null)
                {
                    ss = "" + Symbol;
                }
                if (ss.Length == 0)
                {
                    ss = "" + Symbol;
                }
                return (int)PureDrawableSymbol.Graphics.MeasureString(ss, PureDrawableSymbol.FontsBold[0]).Width;
            }
        }

        /// <summary>
        /// Draws itself on component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">The drawing brush</param>
        /// <param name="pen">The drawing pen</param>
        public static void DrawOnComponent(IDrawableSymbol sym, Graphics g, Brush brush, Pen pen)
        {
            MathSymbol ms = sym as MathSymbol;
            char ch = ms.Symbol;
            if ((ch != '\u2216') & (ch != '\u2217') & (ch != '\u8835') & (ch != '\u2295') & (ch != '\u2297')
                | MathFormula.Resources.ContainsKey(ms.Symbol + ""))
            {
                SimpleSymbolDrawable.DrawOnComponent(sym, g, brush, pen);
                return;
            }

            PureDrawableSymbol pDrawable = sym.PureDrawable;

            int shift = 8;
            string ss = ms.String;
            if (ss == null)
            {
                ss = "" + ch;
            }
            if (ss.Length == 0)
            {
                ss += ch;
            }
            int w = (int)g.MeasureString(ss, BracketsSymbolDrawable.FontB).Width;
            int h = pDrawable.RectForShow.Height;
            int s = (w < h) ? w : h;
            s = (int)(0.6 * (float)s);
            int x = pDrawable.RectForShow.X + w / 2;
            int y = pDrawable.RectForShow.Y + h / 2;
            if (ch == '\u2216')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + shift, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + shift);
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width - shift, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift);
            }
            else if (ch == '\u2217')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + shift, pDrawable.RectForShow.Y + shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift);
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width - shift, pDrawable.RectForShow.Y + shift);
            }
            else if (ch == '\u8835')
            {
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + shift, pDrawable.RectForShow.Y + shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift);
                g.DrawLine(PureDrawableSymbol.WidePen, pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height - shift,
                    pDrawable.RectForShow.X + pDrawable.RectForShow.Width - shift, pDrawable.RectForShow.Y + shift);
            }
            else if (ch == '\u2295')
            {
                DrawCircledPlus(g, PureDrawableSymbol.LinePen, x, y, s);
            }
            else if (ch == '\u2297')
            {
                DrawCircledProduct(g, PureDrawableSymbol.LinePen, x, y, s);
            }
        }


        internal static void DrawCircle(Graphics g, Pen pen, int left, int top, int right, int bottom)
        {
            g.DrawEllipse(pen, left, top, right - left, bottom - top);
        }

        internal static void DrawProduct(Graphics g, Pen pen, int left, int top, int right, int bottom, float coeff)
        {
            float x = (float)(left + right) / 2;
            float y = (float)(top + bottom) / 2;
            float dx = (float)(0.5 * (coeff * (float)(right - left)));
            float dy = (float)(0.5 * (coeff * (float)(bottom - top)));
            g.DrawLine(pen, x - dx, y - dy, x + dx, y + dy);
            g.DrawLine(pen, x - dx, y + dy, x + dx, y - dy);
        }


        internal static void DrawPlus(Graphics g, Pen pen, int left, int top, int right, int bottom, float coeff)
        {
            float x = (float)(left + right) / 2;
            float y = (float)(top + bottom) / 2;
            float dx = (float)(0.5 * (coeff * (float)(right - left)));
            float dy = (float)(0.5 * (coeff * (float)(bottom - top)));
            g.DrawLine(pen, x, y - dy, x, y + dy);
            g.DrawLine(pen, x - dx, y, x + dx, y);
        }

        internal static void DrawCircledProduct(Graphics g, Pen pen, int x, int y, int size)
        {
            int s = size / 2;
            DrawCircledProduct(g, pen, x - s, y - s, x + s, y + s);
        }

        internal static void DrawCircledPlus(Graphics g, Pen pen, int x, int y, int size)
        {
            int s = size / 2;
            DrawCircledPlus(g, pen, x - s, y - s, x + s, y + s);
        }


        internal static void DrawCircledProduct(Graphics g, Pen pen, int left, int top, int right, int bottom)
        {
            DrawCircle(g, pen, left, top, right, bottom);
            DrawProduct(g, pen, left, top, right, bottom, (float)(Math.Sqrt(2) / 2));
        }

        internal static void DrawCircledPlus(Graphics g, Pen pen, int left, int top, int right, int bottom)
        {
            DrawCircle(g, pen, left, top, right, bottom);
            DrawPlus(g, pen, left, top, right, bottom, 1);
        }


        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            DrawOnComponent(this, g, brush, pen);
        }



        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            if ((symbol != '\u2216') & (symbol != '\u2217') & (symbol != '\u8835')
                & (symbol != '\u2295') & (symbol != '\u2297') | MathFormula.Resources.ContainsKey(symbol + ""))
            {
                SimpleSymbolDrawable.DrawSelf(this, g);
                return;
            }
            int x = pDrawable.Position.X;
            int y = pDrawable.Position.Y;
            Rectangle r = pDrawable.FullRelativeRectangle;
            int h = r.Height;
            int w = r.Width;
            DrawHelp(g, x, y, w, h, symbol);
        }

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = pDrawable.Font;//fonts[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            string ss = s;
            if (ss == null)
            {
                ss = "" + Symbol;
            }
            if (ss.Length == 0)
            {
                ss += Symbol;
            }
            int w = (int)PureDrawableSymbol.Graphics.MeasureString(ss /*+ "i"*/, f).Width;
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -h / 2;
            pDrawable.RelativeRectangleWidth = w;
            pDrawable.RelativeRectangleHeight = h;
        }

        /// <summary>
        /// Calculates positions of children
        /// </summary>
        public void CalculateChildPositions()
        {
        }

        public void Prepare(FormulaEditorPerformer performer)
        {
            SimpleSymbolDrawable.Prepare(this, performer);
        }



        #endregion

        #region IPureDrawableSymbol Members

        public PureDrawableSymbol PureDrawable
        {
            get
            {
                return pDrawable;
            }
        }

        #endregion
    }
}
