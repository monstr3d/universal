using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{
    /// <summary>
    /// Drawable brakets
    /// </summary>
    public class BracketsSymbolDrawable : BracketsSymbol, IDrawableSymbol
    {

        #region Fields

        /// <summary>
        /// The bold pDrawable.Font
        /// </summary>
        protected static Font fontB;

        /// <summary>
        /// The down shift 
        /// </summary>
        protected int down;

        /// <summary>
        /// The up & down shift
        /// </summary>
        protected int updown;

        /// <summary>
        ///  The horizontal arc shift 
        /// </summary>
        protected int warc;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int h, hpow;


        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();

        #endregion

        #region Ctor

        public BracketsSymbolDrawable(BracketsSymbol symbol)
        {
        }

        #endregion

        #region IDrawableSymbol Members

        PureDrawableSymbol IDrawableSymbol.PureDrawable
        {
            get
            {
                return pDrawable;
            }
        }



        /// <summary>
        /// Calculates its and its children positions
        /// </summary>
        public static void CalculatePositions(IDrawableSymbol symbol)
        {
            SimpleSymbolDrawable.CalculatePositions(symbol);
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.InsertedRectX = pDrawable.Rectangle.X;
            pDrawable.InsertedRectY = pDrawable.Rectangle.Y;
            pDrawable.InsertedRectHeight = pDrawable.Rectangle.Height;
            pDrawable.InsertedRectWidth = pDrawable.WidthInsert;
            pDrawable.InsertedRectX = pDrawable.InsertedRect.X - pDrawable.WidthInsert / 2;
        }

        public void CalculatePositions()
        {
            CalculatePositions(this);
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
            pDrawable.SetToFormula(formula);

            pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            if (!GetType().Equals(typeof(BracketsSymbolDrawable)))
            {
                return;
            }
            MathFormula child1 =
                new MathFormulaDrawable(new MathFormula((byte)(level), sizes), DrawableConverter.Object);
            children.Add(child1);
            pDrawable.ChildPositions = new Point[] { new Point() };
            if (sizes == null)
            {
                return;
            }
            if (level < (sizes.Length - 1))
            {
                MathFormula child2 = new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child2);
                pDrawable.ChildPositions = new Point[] { new Point(), new Point() };
                return;
            }
        }

        /// <summary>
        /// Calculates relative rectangle with its children
        /// </summary>
        public static void CalculateFullRelativeRectangle(IDrawableSymbol symbol)
        {
            SimpleSymbolDrawable.CalculateFullRelativeRectangle(symbol);
            //SimpleSymbolDrawable.C
            symbol.CalculateRelativeRectangle();
            if (symbol is RootSymbol | symbol is FractionSymbol | symbol is BinaryFunctionSymbol)
            {
                return;
            }
            if (!(symbol is BracketsSymbolDrawable))
            {
                return;
            }
            BracketsSymbolDrawable sym = symbol as BracketsSymbolDrawable;
            Rectangle rr = symbol.PureDrawable.RelativeRectangle;
            int w = rr.Width;
            int up = rr.Y;
            MathSymbol ms = symbol as MathSymbol;
            MathFormulaDrawable df = ms[0] as MathFormulaDrawable;
            Rectangle r1 = df.FullRelativeRectangle;
            Rectangle r2 = new Rectangle();
            if (ms.Children != null)
            {
                if (ms.Count > 1)
                {
                    if (ms[1] != null)
                    {
                        if (!ms[1].IsEmpty)
                        {
                            MathFormulaDrawable dr = ms[1] as MathFormulaDrawable;
                            r2 = dr.FullRelativeRectangle;
                        }
                    }
                }
            }
            sym.h = (int)((double)sym.down / Math.Sin(40.0 * 3.1415926 / 180.0));
            sym.warc = (int)((double)sym.h * (1 - Math.Cos(40.0 * 3.1415926 / 180.0)));
            int wpow = 0, hpow = 0;
            if (sym.Count > 1)
            {
                sym.h = (int)((double)sym.down / Math.Sin(40.0 * 3.1415926 / 180.0));
                sym.warc = (int)((double)sym.h * (1 - Math.Cos(40.0 * 3.1415926 / 180.0)));
                if (ms.Count > 1)
                {
                    wpow = r2.Width;
                    hpow = -r2.Y;
                }
            }
            PureDrawableSymbol pDrawable = symbol.PureDrawable;

            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -sym.down - hpow;
            pDrawable.FullRelativeRectangleWidth = r1.Width + 2 * sym.warc + 4 + wpow;
            pDrawable.FullRelativeRectangleHeight = 2 * sym.down + sym.hpow;
        }

        /// <summary>
        /// Calculates relative rectangle with its children
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            CalculateFullRelativeRectangle(this);
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
        /// Draws itself on component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">The drawing brush</param>
        /// <param name="pen">The drawing pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            int x = pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2 - (int)g.MeasureString(s, fontB).Width / 2;
            g.DrawString(s, fontB, brush, x, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            int x = pDrawable.Position.X;
            int y = pDrawable.Position.Y;
            MathFormulaDrawable f = this[0] as MathFormulaDrawable;
            Rectangle r = f.FullRelativeRectangle;
            warc = (int)((double)h * (1 - Math.Cos(40.0 * Math.PI / 180.0)));
            g.DrawArc(PureDrawableSymbol.LinePen, x + 2, y - h, 2 * h, 2 * h, 140, 80);
            g.DrawArc(PureDrawableSymbol.LinePen, x + 2 + 2 * warc + r.Width - 2 * h, y - h, 2 * h, 2 * h, -40, 80);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            if (children != null)
            {
                if (this[0] != null)
                {
                    MathFormulaDrawable f = this[0] as MathFormulaDrawable;
                    Rectangle r = f.FullRelativeRectangle;
                    int a1 = Math.Abs(r.Y);
                    int a2 = r.Height + r.Y;
                    down = (a1 > a2) ? a1 : a2;
                    updown = down;
                    pDrawable.RelativeRectangleX = 0;
                    pDrawable.RelativeRectangleY = -down;
                    pDrawable.RelativeRectangleWidth = r.Width;
                    pDrawable.RelativeRectangleHeight = 2 * down;
                }
            }
        }

        /// <summary>
        /// Calculates positions of children
        /// </summary>
        public void CalculateChildPositions()
        {
            Rectangle r = pDrawable.FullRelativeRectangle;
            int x = pDrawable.Position.X;
            int y = pDrawable.Position.Y;
            warc = (int)(h * (1 - Math.Cos(40.0 * Math.PI / 180.0)));
            if (true)
            {
                MathFormula child = this[0];
                int dx = 2 + warc;
                Point p = GetChildPosition(0);
                p.X = pDrawable.Position.X;
                p.Y = pDrawable.Position.Y;
                p.X += dx;
                pDrawable.ChildPositions[0].X = p.X;
                pDrawable.ChildPositions[0].Y = p.Y;
                if (Count == 2)
                {
                    if (this[1] != null)
                    {
                        p = GetChildPosition(1);
                        p.X = pDrawable.Position.X;
                        p.Y = pDrawable.Position.Y;
                        int dy = -updown;
                        MathFormulaDrawable f0 = this[0] as MathFormulaDrawable;
                        dx = 4 + 2 * warc + f0.FullRelativeRectangle.Width;
                        p.X += dx;
                        p.Y += dy;
                        pDrawable.ChildPositions[1].X = p.X;
                        pDrawable.ChildPositions[1].Y = p.Y;
                    }
                }
            }
        }
        public Point GetChildPosition(int n)
        {
            return MathSymbolDrawable.GetChildPosition(this, n);
        }

        /// <summary>
        /// Preparation of symbol
        /// </summary>
        /// <param name="performer">The editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
        {
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * fontB.Height);
            int w = (int)g.MeasureString(s + "ii", fontB).Width;
            Image image = new Bitmap(w, h);
            pDrawable.SetImage(image);
            Graphics gr = Graphics.FromImage(image);
            gr.FillRectangle(PureDrawableSymbol.WhiteBrush, 0, 0, w, h);
            gr.DrawString(s, fontB, PureDrawableSymbol.SymbolBrush, gr.MeasureString("i", fontB).Width, PureDrawableSymbol.TOP_SHIFT);
            ((Bitmap)image).MakeTransparent(Color.White);
        }

        /// <summary>
        /// Calculates rectangle for showing on desktop
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Www", PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
        }


        #endregion

        #region Public Members

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BracketsSymbolDrawable(this);
        }


        /// <summary>
        /// Bold pDrawable.Font
        /// </summary>
        public static Font FontB
        {
            get
            {
                return fontB;
            }
        }

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="sizes">The array of different level symbols sizes</param>
        /// <param name="g">the graphics to define font</param>
        public static void Prepare(int[] sizes, Graphics g)
        {
            fontB = new Font("Times", sizes[0], FontStyle.Bold);
        }

        #endregion


    }
}