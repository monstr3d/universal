using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{

    public abstract class MathSymbolDrawable : MathSymbol, IDrawableSymbol
    {

        /// <summary>
        /// Gets removed by mouse click symbol
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="p">the mouse position</param>
        /// <returns>the removed symbol</returns>
        public static IDrawableSymbol GetRemovedSymbol(MathSymbol symbol, Point p)
        {
            if (symbol.Children != null)
            {
                for (int i = 0; i < symbol.Count; i++)
                {
                    MathFormulaDrawable form = symbol[i] as MathFormulaDrawable;
                    IDrawableSymbol sym = form.GetRemovedSymbol(p);
                    if (sym != null)
                    {
                        return sym;
                    }
                }
            }
            IDrawableSymbol s = symbol as IDrawableSymbol;
            if (s.PureDrawable.FullRectangle.Contains(p))
            {
                return s;
            }
            return null;
        }


        public PureDrawableSymbol PureDrawable
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Finds object to insert
        /// </summary>
        /// <param name="p">The position of object</param>
        /// <returns>The object to insert</returns>
        public static IInsertedObject GetInsertedObject(MathSymbol sym, Point p)
        {
            IDrawableSymbol dr = sym as IDrawableSymbol;
            if (sym.Children != null)
            {
                for (int i = 0; i < sym.Count; i++)
                {
                    MathFormulaDrawable form = sym[i] as MathFormulaDrawable;
                    IInsertedObject obj = form.GetInsertedObject(p);
                    if (obj != null)
                    {
                        return obj;
                    }
                }
            }
            if (dr.InsertedRect.Contains(p))
            {
                return dr;
            }
            return null;
        }


        #region IDrawableSymbol Members


        /// <summary>
        /// Sets location on toolbar
        /// </summary>
        /// <param name="x">the x position</param>
        /// <param name="y">the y position</param>
        public static void SetLocationOnTable(IDrawableSymbol symbol, int x, int y)
        {
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.SetLocationOnTable(x, y);
        }



        /// <summary>
        /// Calculates positions of all children
        /// </summary>
        public void CalculatePositions()
        {
            CalculatePositions(this);
        }


        /// <summary>
        /// Calculates positions of all children
        /// </summary>
        public static void CalculatePositions(IDrawableSymbol symbol)
        {
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.FullRectangleX = pDrawable.FullRelativeRectangle.X;
            pDrawable.FullRectangleY = pDrawable.FullRelativeRectangle.Y;
            pDrawable.FullRectangleWidth = pDrawable.FullRelativeRectangle.Width;
            pDrawable.FullRectangleHeight = pDrawable.FullRelativeRectangle.Height;
            pDrawable.FullRectangleX = pDrawable.FullRelativeRectangle.X;
            pDrawable.FullRectangleY = pDrawable.FullRelativeRectangle.Y;
            Point p = pDrawable.Position;
            pDrawable.FullRectangleX = pDrawable.FullRectangle.X + p.X;
            pDrawable.FullRectangleY = pDrawable.FullRectangle.Y + p.Y;
            symbol.CalculateChildPositions();
            MathSymbol ms = symbol as MathSymbol;
            if (ms.Children != null)
            {
                for (int i = 0; i < ms.Count; i++)
                {
                    MathFormulaDrawable child = ms[i] as MathFormulaDrawable;
                    if (child != null)
                    {
                        child.Position = MathSymbolDrawable.GetChildPosition(symbol, i);
                        child.CalculatePositions();
                    }
                }
            }
            pDrawable.RectangleX = pDrawable.FullRelativeRectangle.X;
            pDrawable.RectangleY = pDrawable.FullRelativeRectangle.Y;
            pDrawable.RectangleWidth = pDrawable.FullRelativeRectangle.Width;
            pDrawable.RectangleHeight = pDrawable.FullRelativeRectangle.Height;
            pDrawable.RectangleX = pDrawable.Rectangle.X + p.X;
            pDrawable.RectangleY = pDrawable.Rectangle.Y + p.Y;
        }

        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public Rectangle FullRelativeRectangle
        {
            get
            {
                return new Rectangle();
            }
        }

        /// <summary>
        /// the symbol full rectangle
        /// </summary>
        public Rectangle FullRectangle
        {
            get
            {
                return new Rectangle();
            }
        }

        /// <summary>
        /// Gets the symbol relative rectangle
        /// </summary>
        public Rectangle RelativeRectangle
        {
            get
            {
                return new Rectangle();
            }
        }

        /// <summary>
        /// Gets the symbol rectangle
        /// </summary>
        public Rectangle SymbolRectangle
        {
            get
            {
                return new Rectangle();
            }
        }


        /// <summary>
        /// Draws the sybmol and all its children
        /// </summary>
        /// <param name="g">the graphics for draw</param>
        public static void Draw(MathSymbol symbol, Graphics g)
        {
            IDrawableSymbol dr = symbol as IDrawableSymbol;
            dr.DrawSelf(g);
            if (symbol.Children != null)
            {
                for (int i = 0; i < symbol.Count; i++)
                {
                    MathFormulaDrawable f = symbol[i] as MathFormulaDrawable;
                    f.Draw(g);
                }
            }
        }

        public abstract Rectangle InsertedRect
        {
            get;
        }



        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public static void CalculateFullRelativeRectangle(IDrawableSymbol sym)
        {
            MathSymbol s = sym as MathSymbol;
            if (s.Children != null)
            {
                for (int i = 0; i < s.Count; i++)
                {
                    MathFormulaDrawable f = s[i] as MathFormulaDrawable;
                    f.CalculateFullRelativeRectangle();
                }
            }
        }

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            CalculateFullRelativeRectangle(this);
        }



        public int StandardWidth
        {
            get
            {
                return 1;
            }
        }




        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            // TODO:  Add MathSymbolDrawable.DrawOnComponent implementation
        }

        /// <summary>
        /// Draws the symbol without children
        /// </summary>
        /// <param name="g">the graphics for draw</param>
        public abstract void DrawSelf(Graphics g);

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
          public void CalculateRelativeRectangle()
        {
  
        }

        public void CalculateChildPositions()
        {
 
        }

        public void Prepare(FormulaEditorPerformer performer)
        {

        }

        public void CalculateRectangleForShow()
        {
       }

        /// <summary>
        /// Gets a child position
        /// </summary>
        /// <param name="n">The number of the child</param>
        /// <returns>The position</returns>
        public static Point GetChildPosition(IDrawableSymbol symbol, int n)
        {
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            return (Point)pDrawable.ChildPositions[n];
        }

        /// <summary>
        /// Rectangle for showing on desktop
        /// </summary>
        public Rectangle RectForShow
        {
            get
            {
                return new Rectangle();
            }
            set
            {
                /*rectForShow.X   = value.X;
                rectForShow.Y = value.Y;
                rectForShow.Width  = value.Width;
                rectForShow.Height = value.Height;*/
            }

        }

        public static void SetComponentPosition(IDrawableSymbol drawable, Point p)
        {
            PureDrawableSymbol pure = drawable.PureDrawable;
            pure.ComponentPosition = p;
        }

        public static Rectangle GetFullRelativeRectangle(IDrawableSymbol drawable)
        {
            PureDrawableSymbol pure = drawable.PureDrawable;
            return pure.FullRelativeRectangle;
        }

        public static Rectangle GetRectForShow(IDrawableSymbol drawable)
        {
            PureDrawableSymbol pure = drawable.PureDrawable;
            return pure.RectForShow;
        }


        #endregion

        #region IInsertedObject Members



        #endregion


    }



    public class SimpleSymbolDrawable : SimpleSymbol, IDrawableSymbol
    {
        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();

        public SimpleSymbolDrawable(SimpleSymbol symbol) :
            base(symbol.Symbol, symbol.SymbolType, symbol.Italic, symbol.String)
        {
            bold = symbol.Bold;
            BoolValue = symbol.BoolValue;
            CalculateRectangleForShow();
        }

        public override object Clone()
        {
            return new SimpleSymbolDrawable(this);
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


        /// <summary>
        /// Calculates positions of this object and its children
        /// </summary>
        public static void CalculatePositions(IDrawableSymbol symbol)
        {
            MathSymbolDrawable.CalculatePositions(symbol);
            if (symbol is BracketsSymbol & !(symbol is BinaryFunctionSymbol))
            {
                return;
            }
            //SimpleSymbolDrawable.CalculatePositions(symbol);
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.InsertedRectX = pDrawable.Rectangle.X;
            pDrawable.InsertedRectY = pDrawable.Rectangle.Y;
            pDrawable.InsertedRectWidth = pDrawable.Rectangle.Width;
            pDrawable.InsertedRectHeight = pDrawable.Rectangle.Height;
            pDrawable.InsertedRectX = pDrawable.InsertedRect.X - pDrawable.RelativeRectangle.Width / 2;
        }

        public void CalculatePositions()
        {
            CalculatePositions(this);
        }

        public Rectangle FullRelativeRectangle
        {
            get
            {
                return pDrawable.FullRelativeRectangle;
            }
        }

        public Rectangle FullRectangle
        {
            get
            {
                return pDrawable.FullRectangle;
            }
        }

        public Rectangle RelativeRectangle
        {
            get
            {
                return pDrawable.RelativeRectangle;
            }
        }

        public Rectangle SymbolRectangle
        {
            get
            {
                return pDrawable.SymbolRectangle;
            }
        }

        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        /// <summary>
        /// Sets this object to formula
        /// </summary>
        /// <param name="formula">the formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            SetToFormula(this, formula);
        }



        /// <summary>
        /// Sets this object to formula
        /// </summary>
        /// <param name="formula">the formula to set</param>
        public static void SetToFormula(IDrawableSymbol symbol, MathFormula formula)
        {
            SimpleSymbol sym = symbol as SimpleSymbol;
            sym.Sizes = formula.Sizes;
            sym.Level = formula.Level;
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.SetToFormula(formula);
            if (sym.Italic & sym.Bold)
            {
                pDrawable.Font = PureDrawableSymbol.FontsItalic[sym.Level];
            }
            else if (sym.Italic)
            {
                pDrawable.Font = PureDrawableSymbol.FontsNoBoldItalic[sym.Level];
            }
            else if (sym.Bold)
            {
                pDrawable.Font = PureDrawableSymbol.FontsBold[sym.Level];
            }
            else
            {
                pDrawable.Font = PureDrawableSymbol.Fonts[sym.Level];
            }
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            if (symbol is BracketsSymbol | symbol is BinarySymbol | symbol is BinaryFunctionSymbol)
            {
                return;
            }
            if (sym.Level < (sym.Sizes.Length - 1))
            {
                MathFormulaDrawable child =
                    new MathFormulaDrawable(new MathFormula((byte)(sym.Level + 1), sym.Sizes), DrawableConverter.Object);
                sym.Children.Add(child);
                pDrawable.ChildPositions = new Point[] { new Point() };
                return;
            }
            sym.Children = null;
        }

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public static void CalculateFullRelativeRectangle(IDrawableSymbol symbol)
        {
            MathSymbolDrawable.CalculateFullRelativeRectangle(symbol);
            //base.CalculateFullRelativeRectangle();
            if (symbol is BracketsSymbol)
            {
                return;
            }
            symbol.CalculateRelativeRectangle();
            Rectangle rr = symbol.PureDrawable.RelativeRectangle;
            int w = rr.Width;
            int up = rr.Y;
            int delta = 0;
            MathSymbol ms = symbol as MathSymbol;
            if (ms.Children != null)
            {
                if (ms[0].Count != 0)
                {
                    MathFormulaDrawable dr = ms[0] as MathFormulaDrawable;
                    Rectangle r = dr.FullRelativeRectangle;
                    w += r.Width;
                    delta = rr.Height / 2 - r.Height;
                    up = rr.Y + delta;
                }
            }
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = up;
            pDrawable.FullRelativeRectangleWidth = w;
            pDrawable.FullRelativeRectangleHeight = rr.Height - delta;
        }

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            CalculateFullRelativeRectangle(this);
        }


        /// <summary>
        /// Standard width
        /// </summary>
        public int StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            }
        }

        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            DrawOnComponent(this, g, brush, pen);
        }
        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public static void DrawOnComponent(IDrawableSymbol sym, Graphics g, Brush brush, Pen pen)
        {
            MathSymbol ms = sym as MathSymbol;
            SimpleSymbol ss = ms as SimpleSymbol;
            Font f = null;
            if (ss.Italic & ss.Bold)
            {
                f = PureDrawableSymbol.FontsItalic[ms.Level];
            }
            else if (ss.Italic)
            {
                f = PureDrawableSymbol.FontsNoBoldItalic[ms.Level];
            }
            else if (ss.Bold)
            {
                f = PureDrawableSymbol.FontsBold[ms.Level];
            }
            else
            {
                f = PureDrawableSymbol.Fonts[ms.Level];
            }
            int x = (int)(sym.PureDrawable.RectForShow.X + sym.PureDrawable.RectForShow.Width / 2 - g.MeasureString(ms.String, f).Width / 2);
            g.DrawString(ms.String, f, brush, x, sym.PureDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        /// <summary>
        /// Draws this object without children
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public static void DrawSelf(IDrawableSymbol sym, Graphics g)
        {
            PureDrawableSymbol pDrawable = sym.PureDrawable;

            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;

            MathSymbol ms = sym as MathSymbol;
            if (ms.String[0] == '.' & !MathFormula.Resources.ContainsKey("."))
            {
                g.DrawString(MathSymbol.DecimalSep, pDrawable.Font, PureDrawableSymbol.SymbolBrush,
                    pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2) * g.MeasureString(ms.String, pDrawable.Font).Width), y);
                return;
            }
            g.DrawString(ms.String, pDrawable.Font, PureDrawableSymbol.SymbolBrush,
                pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2) * g.MeasureString(ms.String, pDrawable.Font).Width), y);
        }


        /// <summary>
        /// Draws this object without children
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            DrawSelf(this, g);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)PureDrawableSymbol.Graphics.MeasureString(s /*+ "i"*/, f).Width;
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
            if (children != null)
            {
                MathFormulaDrawable child = this[0] as MathFormulaDrawable;
                int y = pDrawable.Position.Y - child.FullRelativeRectangle.Height / 2;
                pDrawable.ChildPositions[0].X = pDrawable.Position.X + pDrawable.RelativeRectangle.Width;
                pDrawable.ChildPositions[0].Y = y;
            }
        }


        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
        {
            Prepare(this, performer);
        }


        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public static void Prepare(IDrawableSymbol symbol, FormulaEditorPerformer performer)
        {
            Font f = PureDrawableSymbol.Fonts[0];
            SimpleSymbol sym = symbol as SimpleSymbol;
            string s = sym.String;
            if (sym.Italic & sym.Bold)
            {
                f = PureDrawableSymbol.FontsItalic[0];
            }
            else if (sym.Italic)
            {
                f = PureDrawableSymbol.FontsNoBoldItalic[0];
            }
            else if (sym.Bold)
            {
                f = PureDrawableSymbol.FontsBold[0];
            }
            else
            {
                f = PureDrawableSymbol.Fonts[0];
            }
            symbol.PureDrawable.Font = f;
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * symbol.PureDrawable.Font.Height);
            int w = (int)g.MeasureString(s + "i", symbol.PureDrawable.Font).Width;
            g.Dispose();
            Bitmap im = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(im);
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            gr.FillRectangle(brush, 1, 1, w - 2, h - 2);
            gr.DrawRectangle(pen, 0, 0, w - 1, h - 1);
            if (s != null)
            {
                if (!s.Equals("\u2216") & !s.Equals("\u2217") & !s.Equals("\u8835") | MathFormula.Resources.ContainsValue(s))
                {
                    gr.DrawString(s, symbol.PureDrawable.Font,
                        PureDrawableSymbol.SymbolBrush, gr.MeasureString("i", symbol.PureDrawable.Font).Width / 2, PureDrawableSymbol.TOP_SHIFT);
                }
                else
                {
                    BinarySymbolDrawable.DrawHelp(gr, 1, 5, w, h, s[0]);
                }
            }
            gr.Dispose();
            im.MakeTransparent(Color.White);
            symbol.PureDrawable.SetImage(im);
        }

        /// <summary>
        /// Calculates rectangle for menu
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            Font f = PureDrawableSymbol.FontsBold[0];
            SizeF s = g.MeasureString("Wii", f);
            int w = (int)g.MeasureString("Wii", PureDrawableSymbol.FontsBold[0]).Width;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size));
            pDrawable.RectForShow = new Rectangle(0, 0, w, h);
        }

        public Image SymbolImage
        {
            get
            {
                return null;
            }
        }

        public Point GetChildPosition(int n)
        {
            return pDrawable.GetChildPosition(0);
        }

        public Rectangle RectForShow
        {
            get
            {
                return pDrawable.RectForShow;
            }
            set
            {
                pDrawable.RectForShow = value;
            }
        }

        public Point Position
        {
            get
            {
                return pDrawable.Position;
            }
            set
            {
                pDrawable.Position = value;
            }
        }


        /// <summary>
        /// The x coordinate of symbol position
        /// </summary>
        public int X
        {
            get
            {
                return pDrawable.X;
            }
            set
            {
                pDrawable.X = value;
            }
        }

        /// <summary>
        /// The y coordinate of symbol position
        /// </summary>
        public int Y
        {
            get
            {
                return pDrawable.Y;
            }
            set
            {
                pDrawable.Y = value;
            }
        }


        public Point ComponentPosition
        {
            set
            {
                pDrawable.ComponentPosition = value;
            }
        }

        public Rectangle ComponentRectangle
        {
            get
            {
                return pDrawable.ComponentRectangle;
            }
        }

        public PureDrawableSymbol PureDrawable
        {
            get
            {
                return pDrawable;
            }
        }


        #endregion

        #region IInsertedObject Members


        public IInsertedObject GetInsertedObject(Point p)
        {
            // TODO:  Add SimpleSymbolDrawable.GetInsertedObject implementation
            return null;
        }

        #endregion

        public static void DrawHelp(Graphics g, int x, int y, int w, int h, char c)
        {
            double coeff = 0.9;
            int left = (int)((1 - coeff) * w) + x;
            int right = (int)(coeff * w) + x;
            int middle = (int)(w / 2) + x;
            int top = +(int)((1 - coeff) * h) + y;
            int bottom = (int)(coeff * h) + y;
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
            int size = (w < h) ? w : h;
            int xx = left + w / 2;
            int yy = top + h / 2;
            if (c == '\u2295')
            {
                // direct product;
                BinarySymbolDrawable.DrawCircledPlus(g, PureDrawableSymbol.LinePen, xx, yy, size);

            }
            if (c == '\u2297')
            {
                // tensor product
                BinarySymbolDrawable.DrawCircledProduct(g, PureDrawableSymbol.LinePen, xx, yy, size);
            }
        }

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="sizes">Sizes of symbols</param>
        /// <param name="g">Auxiliary graphics</param>
        public static void Prepare(int[] sizes, Graphics g)
        {
            PureDrawableSymbol.FontsBold = new Font[sizes.Length];
            PureDrawableSymbol.Fonts = new Font[sizes.Length];
            PureDrawableSymbol.FontsItalic = new Font[sizes.Length];
            PureDrawableSymbol.FontsNoBoldItalic = new Font[sizes.Length];
            FontFamily[] ff = FontFamily.Families;
            for (int i = 0; i < sizes.Length; i++)
            {
                PureDrawableSymbol.Fonts[i] = new Font("Times New Roman", sizes[i]);
                PureDrawableSymbol.FontsBold[i] = new Font("Times New Roman", sizes[i], FontStyle.Bold);
                PureDrawableSymbol.FontsItalic[i] = new Font("Times New Roman", sizes[i], FontStyle.Italic | FontStyle.Bold);
                PureDrawableSymbol.FontsNoBoldItalic[i] = new Font("Times New Roman", sizes[i], FontStyle.Italic);
            }
            PureDrawableSymbol.SetGraphics(g);
        }


    }

    public class IndexedSymbolDrawable : IndexedSymbol, IDrawableSymbol
    {
        PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        public IndexedSymbolDrawable(IndexedSymbol symbol)
            : base(symbol.Symbol, symbol.SymbolType, symbol.Italic, symbol.String)
        {
        }

        public override object Clone()
        {
            return new IndexedSymbolDrawable(this);
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


        /// <summary>
        /// Calculates positions of this object and its children
        /// </summary>
        public void CalculatePositions()
        {
            CalculatePositions(this);
        }


        /// <summary>
        /// Calculates positions of this object and its children
        /// </summary>
        public static void CalculatePositions(IDrawableSymbol symbol)
        {
            SimpleSymbolDrawable.CalculatePositions(symbol);
            PureDrawableSymbol pDrawable = symbol.PureDrawable;

            pDrawable.InsertedRectX = pDrawable.Position.X;
            pDrawable.InsertedRectY = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            pDrawable.InsertedRectWidth = pDrawable.Rectangle.Width;
            pDrawable.InsertedRectHeight = pDrawable.Rectangle.Height;
            pDrawable.InsertedRectX = pDrawable.InsertedRect.X - pDrawable.RelativeRectangle.Width / 2;
        }

        public Rectangle FullRelativeRectangle
        {
            get
            {
                return pDrawable.FullRelativeRectangle;
            }
        }

        public Rectangle FullRectangle
        {
            get
            {
                return pDrawable.FullRectangle;
            }
        }

        public Rectangle RelativeRectangle
        {
            get
            {
                return pDrawable.RelativeRectangle;
            }
        }

        public Rectangle SymbolRectangle
        {
            get
            {
                return pDrawable.SymbolRectangle;
            }
        }

        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        /// <summary>
        /// Sets this object to formula
        /// </summary>
        /// <param name="formula">the formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            sizes = formula.Sizes;
            level = formula.Level;
            pDrawable.SetToFormula(formula);

            if (italic)
            {
                pDrawable.Font = PureDrawableSymbol.FontsItalic[level];
            }
            else
            {
                pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            }
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            if (!GetType().Equals(typeof(IndexedSymbolDrawable)))
            {
                return;
            }
            if (level < (sizes.Length - 1))
            {
                MathFormula child = new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child);
                pDrawable.ChildPositions = new Point[] { new Point() };
                return;
            }
            children = null;
        }

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public static void CalculateFullRelativeRectangle(IDrawableSymbol symbol)
        {
            SimpleSymbolDrawable.CalculateFullRelativeRectangle(symbol);
            //base.CalculateFullRelativeRectangle();
            symbol.CalculateRelativeRectangle();
            Rectangle rr = symbol.PureDrawable.RelativeRectangle;
            int w = rr.Width;
            int up = rr.Y;
            int delta = 0;
            MathSymbol ms = symbol as MathSymbol;
            if (ms.Children != null)
            {
                if (ms[0].Count != 0)
                {
                    MathFormulaDrawable df = ms[0] as MathFormulaDrawable;
                    Rectangle r = df.FullRelativeRectangle;
                    w += (int)(1.5 * (double)r.Width);
                    delta = rr.Height / 2 + r.Height;
                    up = rr.Y + delta;
                }
            }
            PureDrawableSymbol pDrawable = symbol.PureDrawable;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = up;
            pDrawable.FullRelativeRectangleWidth = w;
            pDrawable.FullRelativeRectangleHeight = rr.Height;
        }


        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            CalculateFullRelativeRectangle(this);
        }



        /// <summary>
        /// Standard width
        /// </summary>
        public int StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            }
        }

        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = (int)(RectForShow.X + pDrawable.RectForShow.Width / 2 - g.MeasureString(s, f).Width / 2);
            g.DrawString(s, f, brush, x, RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        /// <summary>
        /// Draws this object without children
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            g.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush,
                pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2) * g.MeasureString(s, pDrawable.Font).Width), y);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)PureDrawableSymbol.Graphics.MeasureString(s /*+ "i"*/, f).Width;
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
            if (children != null)
            {
                MathFormulaDrawable child = this[0] as MathFormulaDrawable;
                int y = pDrawable.Position.Y + child.FullRelativeRectangle.Height / 2;
                pDrawable.ChildPositions[0].X = pDrawable.Position.X + pDrawable.RelativeRectangle.Width;
                pDrawable.ChildPositions[0].Y = y;
            }
        }

        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
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

        /// <summary>
        /// Calculates rectangle for menu
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Wii", PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
        }

        public Image SymbolImage
        {
            get
            {
                return pDrawable.SymbolImage;
            }
        }

        public Point GetChildPosition(int n)
        {
            return pDrawable.GetChildPosition(n);
        }

        public Rectangle RectForShow
        {
            get
            {
                return pDrawable.RectForShow;
            }
            set
            {
                pDrawable.RectForShow = value;
            }
        }

        public Point Position
        {
            get
            {
                return pDrawable.Position;
            }
            set
            {
                pDrawable.Position = value;
            }
        }

        public int X
        {
            get
            {
                return pDrawable.X;
            }
            set
            {
                pDrawable.X = value;
            }
        }

        public int Y
        {
            get
            {
                return pDrawable.Y;
            }
            set
            {
                pDrawable.Y = value;
            }
        }

        public Point ComponentPosition
        {
            set
            {
                pDrawable.ComponentPosition = value;
            }
        }

        public Rectangle ComponentRectangle
        {
            get
            {
                return pDrawable.ComponentRectangle;
            }
        }

        public PureDrawableSymbol PureDrawable
        {
            get
            {
                return pDrawable;
            }
        }


        #endregion

        #region IInsertedObject Members


        #endregion
    }

    public class PoweredIndexedSymbolDrawable : PoweredIndexedSymbol, IDrawableSymbol
    {
        PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        public PoweredIndexedSymbolDrawable(PoweredIndexedSymbol symbol) :
            base(symbol.Symbol, symbol.SymbolType, symbol.Italic, symbol.String)
        {
        }

        public override object Clone()
        {
            return new PoweredIndexedSymbolDrawable(this);
        }



        #region IDrawableSymbol Members]



        public void CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
        }
        /*
                public Rectangle FullRelativeRectangle
                {
                    get
                    {
                        // TODO:  Add PoweredIndexedSymbolDrawable.FullRelativeRectangle getter implementation
                        return new Rectangle ();
                    }
                }

                public Rectangle FullRectangle
                {
                    get
                    {
                        // TODO:  Add PoweredIndexedSymbolDrawable.FullRectangle getter implementation
                        return new Rectangle ();
                    }
                }*/

        public Rectangle RelativeRectangle
        {
            get
            {
                return pDrawable.RelativeRectangle;
            }
        }
        /*
                public Rectangle SymbolRectangle
                {
                    get
                    {
                        // TODO:  Add PoweredIndexedSymbolDrawable.SymbolRectangle getter implementation
                        return new Rectangle ();
                    }
                }*/

        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        /// <summary>
        /// Sets this object to formula
        /// </summary>
        /// <param name="formula">the formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            level = formula.Level;
            sizes = formula.Sizes;
            pDrawable.SetToFormula(formula);

            if (italic)
            {
                pDrawable.Font = PureDrawableSymbol.FontsItalic[level];
            }
            else
            {
                pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            }
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            /*			if (this is BracketsSymbol | this is BinarySymbol | this is BinaryFunctionSymbol)
                        {
                            return;
                        }*/
            if (level < (sizes.Length - 1))
            {
                MathFormula child =
                    new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child);
                child =
                    new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child);
                pDrawable.ChildPositions = new Point[] { new Point(), new Point() };
                return;
            }
            children = null;
        }


        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {

            IndexedSymbolDrawable.CalculateFullRelativeRectangle(this);
            CalculateRelativeRectangle();
            Rectangle rr = RelativeRectangle;
            int w = rr.Width;
            int wt = 0;
            int wb = 0;
            int up = rr.Y;
            int delta = 0;
            if (children != null)
            {
                if (this[0].Count != 0)
                {
                    MathFormulaDrawable f = this[0] as MathFormulaDrawable;
                    Rectangle r = f.FullRelativeRectangle;
                    wt = (int)(1.5 * (double)r.Width);
                    delta = rr.Height / 2 + r.Height;
                    up = rr.Y + delta;
                }
                if (this[1].Count != 0)
                {
                    MathFormulaDrawable f = this[1] as MathFormulaDrawable;
                    Rectangle r = f.FullRelativeRectangle;
                    wb = (int)(1.5 * (double)r.Width);
                    delta = rr.Height / 2 + r.Height;
                    up = rr.Y + delta;
                }
            }
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = up;
            pDrawable.FullRelativeRectangleWidth = w + ((wt > wb) ? wt : wb);
            pDrawable.FullRelativeRectangleHeight = rr.Height;
        }

        /// <summary>
        /// Standard width
        /// </summary>
        public int StandardWidth
        {

            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            }
        }

        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = (int)(pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2 - g.MeasureString(s, f).Width / 2);
            g.DrawString(s, f, brush, x, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
        }

        /// <summary>
        /// Draws this object without children
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            g.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush,
                pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2) * g.MeasureString(s, pDrawable.Font).Width), y);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)PureDrawableSymbol.Graphics.MeasureString(s, f).Width;
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
            if (children != null)
            {
                MathFormulaDrawable child = this[0] as MathFormulaDrawable;
                int y = pDrawable.Position.Y + child.FullRelativeRectangle.Height / 2;
                pDrawable.ChildPositions[1].X = pDrawable.Position.X + pDrawable.RelativeRectangle.Width;
                pDrawable.ChildPositions[1].Y = y;
                pDrawable.ChildPositions[0].X = pDrawable.ChildPositions[1].X;
                y = pDrawable.Position.Y - child.FullRelativeRectangle.Height / 2;
                pDrawable.ChildPositions[0].Y = y;
            }
        }

        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
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


        /// <summary>
        /// Calculates rectangle for menu
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Wii", PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
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


    public class SeriesSymbolDrawable : SeriesSymbol, IDrawableSymbol
    {

        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();

        public SeriesSymbolDrawable(SeriesSymbol symbol)
            : base(symbol.Index)
        {
        }

        public override object Clone()
        {
            return new SeriesSymbolDrawable(this);
        }

        #region IDrawableSymbol Members



        public void CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
        }
        /*
                public Rectangle FullRelativeRectangle
                {
                    get
                    {
                        // TODO:  Add SeriesSymbolDrawable.FullRelativeRectangle getter implementation
                        return new Rectangle ();
                    }
                }

                public Rectangle FullRectangle
                {
                    get
                    {
                        // TODO:  Add SeriesSymbolDrawable.FullRectangle getter implementation
                        return new Rectangle ();
                    }
                }

                public Rectangle RelativeRectangle
                {
                    get
                    {
                        // TODO:  Add SeriesSymbolDrawable.RelativeRectangle getter implementation
                        return new Rectangle ();
                    }
                }

                public Rectangle SymbolRectangle
                {
                    get
                    {
                        // TODO:  Add SeriesSymbolDrawable.SymbolRectangle getter implementation
                        return new Rectangle ();
                    }
                }*/

        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        /// <summary>
        /// Sets this object to formula
        /// </summary>
        /// <param name="formula">the formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {

            level = formula.Level;
            sizes = formula.Sizes;
            pDrawable.SetToFormula(formula);

            if (italic)
            {
                pDrawable.Font = PureDrawableSymbol.FontsItalic[level];
            }
            else
            {
                pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            }
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            children.Clear();
            if (!GetType().Equals(typeof(SeriesSymbolDrawable)))
            {
                return;
            }
            if (level < (sizes.Length - 1))
            {
                MathFormula child =
                    new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child);
                pDrawable.ChildPositions = new Point[] { new Point() };
                return;
            }
            children = null;
        }

        public void CalculateFullRelativeRectangle()
        {
            SimpleSymbolDrawable.CalculateFullRelativeRectangle(this);
            CalculateRelativeRectangle();
        }

        /// <summary>
        /// Standard width
        /// </summary>
        public int StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)(g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width + g.MeasureString(Index + "", PureDrawableSymbol.FontsBold[1]).Width);
            }
        }


        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = (int)(pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2 - g.MeasureString(s, f).Width / 2);
            int width = (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            g.DrawString(s, f, brush, x, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
            g.DrawString(Index + "", PureDrawableSymbol.FontsBold[1], PureDrawableSymbol.SymbolBrush, x + width, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height / 3);
        }

        /// <summary>
        /// Draws this object without children
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            int width = (int)g.MeasureString(s, pDrawable.Font).Width;
            int x = pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2)) * width;
            g.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, y);
            string indx = Index + "";
            Font f = PureDrawableSymbol.FontsBold[level + 1];
            g.DrawString(indx, f, PureDrawableSymbol.SymbolBrush, x + width, y + pDrawable.Font.Height / 2);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            Font f1 = PureDrawableSymbol.FontsBold[level + 1];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int h1 = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f1.Height));
            int w = (int)(PureDrawableSymbol.Graphics.MeasureString(s, f).Width);
            int w1 = 0;
            if (Count != 0)
            {
                MathFormulaDrawable ch = this[0] as MathFormulaDrawable;
                w1 = ch.FullRelativeRectangle.Width;
            }
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -h / 2;
            pDrawable.RelativeRectangleWidth = w;
            pDrawable.RelativeRectangleHeight = h;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = pDrawable.RelativeRectangle.Y - h1 / 2;
            int wind = (int)PureDrawableSymbol.Graphics.MeasureString(Index + "", f1).Width;
            if (wind > w1)
            {
                w1 = wind;
            }
            pDrawable.FullRelativeRectangleWidth = w + w1;
            pDrawable.FullRelativeRectangleHeight = pDrawable.RelativeRectangle.Height + h1 / 2;
        }

        public void CalculateChildPositions()
        {
            if (children != null)
            {
                MathFormulaDrawable child = this[0] as MathFormulaDrawable;
                int y = pDrawable.Position.Y - child.FullRelativeRectangle.Height / 2;
                pDrawable.ChildPositions[0].X = pDrawable.Position.X + pDrawable.RelativeRectangle.Width;
                pDrawable.ChildPositions[0].Y = y;
            }
        }

        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
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
            Graphics gr = Graphics.FromImage(im);
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            gr.FillRectangle(brush, 1, 1, w - 2, h - 2);
            gr.DrawRectangle(pen, 0, 0, w - 1, h - 1);
            int x = (int)gr.MeasureString("i", pDrawable.Font).Width / 2;
            gr.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, PureDrawableSymbol.TOP_SHIFT);
            gr.DrawString(Index + "", PureDrawableSymbol.FontsBold[1], PureDrawableSymbol.SymbolBrush, x + w1, PureDrawableSymbol.TOP_SHIFT + h / 2);
            gr.Dispose();
            im.MakeTransparent(Color.White);
            pDrawable.SetImage(im);
        }

        /// <summary>
        /// Calculates rectangle for menu
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Wiw", PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
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

    public class SubscriptedSymbolDrawable : SubscriptedSymbol, IDrawableSymbol
    {

        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();

        public SubscriptedSymbolDrawable(SubscriptedSymbol sym)
            : base(sym.String, sym.Pair.Second)
        {
        }

        public override object Clone()
        {
            return new SubscriptedSymbolDrawable(this);
        }

        #region IDrawableSymbol Members



        public void CalculatePositions()
        {
            SimpleSymbolDrawable.CalculatePositions(this);
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
            //base.SetToFormula(formula);
            pDrawable.SetToFormula(formula);
            level = formula.Level;
            sizes = formula.Sizes;
            pDrawable.Font = PureDrawableSymbol.FontsItalic[level];
        }

        public void CalculateFullRelativeRectangle()
        {
            CalculateRelativeRectangle();
        }

        /// <summary>
        /// Standard width
        /// </summary>
        public int StandardWidth
        {
            get
            {
                Graphics g = PureDrawableSymbol.Graphics;
                return (int)(g.MeasureString(s + "W", PureDrawableSymbol.FontsBold[0]).Width + g.MeasureString(sub, PureDrawableSymbol.FontsBold[1]).Width);
            }
        }

        /// <summary>
        /// Draws this symbol on menu component
        /// </summary>
        /// <param name="g">The graphics to draw</param>
        /// <param name="brush">the brush</param>
        /// <param name="pen">the pen</param>
        public void DrawOnComponent(Graphics g, Brush brush, Pen pen)
        {
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = (int)(pDrawable.RectForShow.X + pDrawable.RectForShow.Width / 2 - g.MeasureString(s, f).Width / 2);
            int width = (int)g.MeasureString(s, PureDrawableSymbol.FontsBold[0]).Width;
            g.DrawString(s, f, brush, x, pDrawable.RectForShow.Y + PureDrawableSymbol.TOP_SHIFT);
            g.DrawString(sub, PureDrawableSymbol.FontsBold[1], PureDrawableSymbol.SymbolBrush, x + width, pDrawable.RectForShow.Y + pDrawable.RectForShow.Height / 3);
        }

        public void DrawSelf(Graphics g)
        {
            int y = pDrawable.Position.Y - pDrawable.Font.Height / 2;
            int width = (int)g.MeasureString(s, pDrawable.Font).Width;
            int x = pDrawable.Position.X + (int)((PureDrawableSymbol.W_SHIFT / 2)) * width;
            g.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, y);
            Font f = PureDrawableSymbol.FontsBold[level + 1];
            g.DrawString(sub, f, PureDrawableSymbol.SymbolBrush, x + width, y + pDrawable.Font.Height / 2);
        }

        /// <summary>
        /// Calculates relative rectangle without children
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            Font f = PureDrawableSymbol.FontsBold[level];
            Font f1 = PureDrawableSymbol.FontsBold[level + 1];
            int h = (int)((1 + 2 * PureDrawableSymbol.H_SHIFT) * (f.Height));
            int w = (int)(PureDrawableSymbol.Graphics.MeasureString(s, f).Width + PureDrawableSymbol.Graphics.MeasureString(sub, f1).Width);
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -h / 2;
            pDrawable.RelativeRectangleWidth = w;
            pDrawable.RelativeRectangleHeight = h;
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -h / 2;
            pDrawable.FullRelativeRectangleWidth = w;
            pDrawable.FullRelativeRectangleHeight = h;
        }

        public void CalculateChildPositions()
        {
        }


        /// <summary>
        /// Prepares itself for editing
        /// </summary>
        /// <param name="performer">the editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
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
            Graphics gr = Graphics.FromImage(im);
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);
            gr.FillRectangle(brush, 1, 1, w - 2, h - 2);
            gr.DrawRectangle(pen, 0, 0, w - 1, h - 1);
            int x = (int)gr.MeasureString("i", pDrawable.Font).Width / 2;
            gr.DrawString(s, pDrawable.Font, PureDrawableSymbol.SymbolBrush, x, PureDrawableSymbol.TOP_SHIFT);
            gr.DrawString(sub, PureDrawableSymbol.FontsBold[1], PureDrawableSymbol.SymbolBrush, x + w1, PureDrawableSymbol.TOP_SHIFT + h / 2);
            gr.Dispose();
            im.MakeTransparent(Color.White);
            pDrawable.SetImage(im);
        }

        /// <summary>
        /// Calculates rectangle for menu
        /// </summary>
        public void CalculateRectangleForShow()
        {
            Graphics g = PureDrawableSymbol.Graphics;
            pDrawable.RectForShow = new Rectangle(0, 0, (int)g.MeasureString("Wiw" + s + sub, PureDrawableSymbol.FontsBold[0]).Width,
                (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * (PureDrawableSymbol.FontsBold[0].Size)));
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

    public class RootSymbolDrawable : RootSymbol, IDrawableSymbol
    {


        /// <summary>
        /// Auxiliary variable
        /// </summary>
        private int up, w, down, updown;

        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        public RootSymbolDrawable(RootSymbol symbol)
        {
        }

        public override object Clone()
        {
            return new RootSymbolDrawable(this);
        }

        #region IDrawableSymbol Members



        public void CalculatePositions()
        {
            BracketsSymbolDrawable.CalculatePositions(this);
            CalculateChildPositions();
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
            level = formula.Level;
            sizes = formula.Sizes;
            SimpleSymbolDrawable.SetToFormula(this, formula);
            pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            MathFormulaDrawable child =
                new MathFormulaDrawable(new MathFormula((byte)(level), sizes), DrawableConverter.Object);
            children.Add(child);
            if (level < (sizes.Length - 1))
            {
                MathFormulaDrawable child1 =
                    new MathFormulaDrawable(new MathFormula((byte)(level + 1), sizes), DrawableConverter.Object);
                children.Add(child1);
                pDrawable.ChildPositions = new Point[] { new Point(), new Point() };
                return;
            }


        }

        /// <summary>
        /// Calculates relative rectangle with its children
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            BracketsSymbolDrawable.CalculateFullRelativeRectangle(this);
            Rectangle sn = pDrawable.RelativeRectangle, sd = new Rectangle();
            w = 0;
            if (children != null)
            {
                if (this[0] != null)
                {
                    MathFormulaDrawable f = this[0] as MathFormulaDrawable;
                    sn = f.FullRelativeRectangle;
                }
                if (Count > 1)
                {
                    if (this[1] != null)
                    {
                        MathFormulaDrawable f = this[1] as MathFormulaDrawable;
                        sd = f.FullRelativeRectangle;
                    }
                }
            }
            up = -sn.Y;
            down = sn.Y + sn.Height;
            updown = (up > down) ? up : down;
            if (Count > 1)
            {
                w = sd.Width;
            }
            else
            {
                w = (int)PureDrawableSymbol.Graphics.MeasureString("i", pDrawable.Font).Width;
            }
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -updown - 2;
            pDrawable.FullRelativeRectangleWidth = w + 6 + 2 * updown / 3 + 10 + sn.Width;
            pDrawable.FullRelativeRectangleHeight = 2 * updown + 4;
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
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            Rectangle r = pDrawable.RectForShow;
            int w = r.Width / 3;
            int x = r.X + 2;
            int y = r.Y + r.Height / 2;
            int updown = r.Height / 2 - 6;
            int h = r.Height - 8;
            g.DrawLine(pen, x + 4, y, x + 6, y);
            g.DrawLine(pen, x + 6, y, x + 6, y + h / 2);
            g.DrawLine(pen, x + 6, y + h / 2, x + 6 + 2 * updown / 3, y - h / 2);
            g.DrawLine(pen, x + 6 + 2 * updown / 3, y - h / 2, x + 6 + 2 * updown / 3 + w, y - h / 2);
        }

        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g"></param>
        public void DrawSelf(Graphics g)
        {
            int x = pDrawable.Position.X;
            int y = pDrawable.Position.Y;
            MathFormulaDrawable f = this[0] as MathFormulaDrawable;
            Rectangle rr = f.FullRelativeRectangle;
            Rectangle r = pDrawable.FullRelativeRectangle;
            g.DrawLine(PureDrawableSymbol.LinePen, x + 4, y, x + 6 + w, y);
            g.DrawLine(PureDrawableSymbol.LinePen, x + 6 + w, y, x + 6 + w, y + r.Y + r.Height);
            g.DrawLine(PureDrawableSymbol.LinePen, x + 6 + w, y + r.Height + r.Y, x + 6 + w + 2 * updown / 3, y + r.Y);
            g.DrawLine(PureDrawableSymbol.LinePen, x + 6 + w + 2 * updown / 3, y + r.Y, x + r.Width, y + r.Y);
        }

        /// <summary>
        /// Calculates relative rectangle
        /// </summary>
        public void CalculateRelativeRectangle()
        {
            if (children != null)
            {
                if (this[0] != null)
                {
                    MathFormulaDrawable f = this[0] as MathFormulaDrawable;
                    Rectangle r = f.FullRelativeRectangle;
                    pDrawable.RelativeRectangleX = r.X;
                    pDrawable.RelativeRectangleY = r.Y;
                    pDrawable.RelativeRectangleWidth = r.Width;
                    pDrawable.RelativeRectangleHeight = r.Height;
                }
            }
        }

        /// <summary>
        /// Calculates positions of children
        /// </summary>
        public void CalculateChildPositions()
        {
            Point p;
            int dx, dy;
            if (Count > 1)
            {
                if (this[1] != null)
                {
                    p = GetChildPosition(1);
                    dx = 4;
                    MathFormulaDrawable f1 = this[1] as MathFormulaDrawable;
                    Rectangle r = f1.FullRelativeRectangle;
                    p.X = pDrawable.Position.X;
                    p.Y = pDrawable.Position.Y;
                    dy = -r.Height / 2 - 3;
                    p.X += dx;
                    p.Y += dy;
                    pDrawable.ChildPositions[1].X = p.X;
                    pDrawable.ChildPositions[1].Y = p.Y;
                }
            }
            p = GetChildPosition(0);
            p.X = pDrawable.Position.X;
            dx = 6 + w + 2 * updown / 3;
            p.X += dx;
            pDrawable.ChildPositions[0].X = p.X;
            pDrawable.ChildPositions[0].Y = pDrawable.Position.Y;
        }

        /// <summary>
        /// Prepares itself
        /// </summary>
        /// <param name="performer">Editor performer</param>
        public void Prepare(FormulaEditorPerformer performer)
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
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * PureDrawableSymbol.FontsBold[0].Height);
            int w = (int)g.MeasureString(s + "i", PureDrawableSymbol.FontsBold[0]).Width;
            g.Dispose();
            Bitmap im = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(im);
            gr.FillRectangle(PureDrawableSymbol.WhiteBrush, 1, 1, w - 2, h - 2);
            w = im.Width / 3;
            int x = 2;
            int y = im.Height / 2;
            int updown = im.Height / 2 - 6;
            h = im.Height - 8;
            gr.DrawLine(PureDrawableSymbol.LinePen, x + 4, y, x + 6, y);
            gr.DrawLine(PureDrawableSymbol.LinePen, x + 6, y, x + 6, y + h / 2);
            gr.DrawLine(PureDrawableSymbol.LinePen, x + 6, y + h / 2, x + 6 + 2 * updown / 3, y - h / 2);
            gr.DrawLine(PureDrawableSymbol.LinePen, x + 6 + 2 * updown / 3, y - h / 2, x + 6 + 2 * updown / 3 + w, y - h / 2);
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

    public class FractionSymbolDrawable : FractionSymbol, IDrawableSymbol
    {
        /// <summary>
        /// The width
        /// </summary>
        private int width, updown;


        private PureDrawableSymbol pDrawable = new PureDrawableSymbol();


        public FractionSymbolDrawable(FractionSymbol symbol)
        {
        }

        public override object Clone()
        {
            return new FractionSymbolDrawable(this);
        }

        #region IDrawableSymbol Members



        public void CalculatePositions()
        {
            BracketsSymbolDrawable.CalculatePositions(this);
            CalculateChildPositions();
        }



        public Rectangle InsertedRect
        {
            get
            {
                return pDrawable.InsertedRect;
            }
        }

        /// <summary>
        /// Sets itself to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            sizes = formula.Sizes;
            level = formula.Level;
            pDrawable.SetToFormula(formula);
            pDrawable.Font = PureDrawableSymbol.FontsBold[level];
            pDrawable.WidthInsert = (int)PureDrawableSymbol.Graphics.MeasureString("y", pDrawable.Font, 100).Width;
            for (int i = 0; i < 2; i++)
            {
                children.Add(new MathFormulaDrawable(new MathFormula((byte)level, sizes), DrawableConverter.Object));
            }
            pDrawable.ChildPositions = new Point[] { new Point(), new Point() };
        }

        /// <summary>
        /// Calculates relative rectangle with children
        /// </summary>
        public void CalculateFullRelativeRectangle()
        {
            BracketsSymbolDrawable.CalculateFullRelativeRectangle(this);
            pDrawable.FullRelativeRectangleX = 0;
            pDrawable.FullRelativeRectangleY = -updown;
            pDrawable.FullRelativeRectangleWidth = width;
            pDrawable.FullRelativeRectangleHeight = 2 * updown;
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
            Font f = (italic) ? PureDrawableSymbol.FontsItalic[level] : PureDrawableSymbol.FontsBold[level];
            int x = pDrawable.RectForShow.X + 1;
            int y = pDrawable.RectForShow.Y;
            int w = pDrawable.RectForShow.Width - 2;
            int h = pDrawable.RectForShow.Height - 2;
            g.DrawLine(pen, x + 2, y + h / 2, x + w - 3, y + h / 2);
            g.DrawRectangle(pen, x + 3, y + 3, w - 7, h / 2 - 5);
            g.DrawRectangle(pen, x + 3, y + h / 2 + 2, w - 7, h / 2 - 5);
        }

        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        public void DrawSelf(Graphics g)
        {
            int x = pDrawable.Position.X;
            int y = pDrawable.Position.Y;
            g.DrawLine(PureDrawableSymbol.LinePen, x + 1, y, x + width - 1, y);
        }

        /// <summary>
        /// Calculates relative rectangle wihout children
        /// </summary>
        public void CalculateRelativeRectangle()
        {

            MathFormulaDrawable[] f = {this[0] as MathFormulaDrawable,
										  this[1] as MathFormulaDrawable};
            Rectangle[] r = new Rectangle[]{f[0].FullRelativeRectangle,
											   f[1].FullRelativeRectangle};
            updown = (int)((1 + PureDrawableSymbol.C_HEIGHT) * ((r[0].Height > r[1].Height) ? r[0].Height : r[1].Height));
            width = 4 + ((r[0].Width > r[1].Width) ? r[0].Width : r[1].Width);
            pDrawable.RelativeRectangleX = 0;
            pDrawable.RelativeRectangleY = -updown;
            pDrawable.RelativeRectangleWidth = width;
            pDrawable.RelativeRectangleHeight = 2 * updown;
        }

        /// <summary>
        /// Calculates positions of child formulas
        /// </summary>
        public void CalculateChildPositions()
        {
            Point[] p = new Point[] { pDrawable.ChildPositions[0], pDrawable.ChildPositions[1] };
            Rectangle[] r = new Rectangle[2];//{this[0].FullRelativeRectangle, this[1].FullRelativeRectangle};
            for (int i = 0; i < 2; i++)
            {
                MathFormulaDrawable f = this[i] as MathFormulaDrawable;
                r[i] = f.FullRelativeRectangle;
                p[i].X = pDrawable.Position.X;
                p[i].Y = pDrawable.Position.Y;
                p[i].X += (width - r[i].Width) / 2;
                p[i].Y += ((i == 0) ? -1 : 1) * (2 + r[i].Height / 2);
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
            Font f;
            if (italic)
            {
                f = PureDrawableSymbol.FontsItalic[0];
            }
            else
            {
                f = PureDrawableSymbol.FontsBold[0];
            }
            IControl c = performer.EditControl;
            Graphics g = c.Graphics;
            int h = (int)((1 + 2 * PureDrawableSymbol.C_HEIGHT) * PureDrawableSymbol.FontsBold[0].Height);
            int w = (int)g.MeasureString(s + "i", PureDrawableSymbol.FontsBold[0]).Width;
            g.Dispose();
            Bitmap im = new Bitmap(w, h);
            g = Graphics.FromImage(im);
            g.FillRectangle(PureDrawableSymbol.WhiteBrush, 1, 1, w - 2, h - 2);
            g.DrawLine(PureDrawableSymbol.LinePen, 2, h / 2, w - 3, h / 2);
            g.DrawRectangle(PureDrawableSymbol.LinePen, 3, 3, w - 7, h / 2 - 5);
            g.DrawRectangle(PureDrawableSymbol.LinePen, 3, h / 2 + 2, w - 7, h / 2 - 5);
            g.Dispose();
            im.MakeTransparent(Color.White);
            pDrawable.SetImage(im);
        }

        public void CalculateRectangleForShow()
        {
            // TODO:  Add FractionSymbolDrawable.CalculateRectangleForShow implementation
        }


        public Point GetChildPosition(int n)
        {
            return MathSymbolDrawable.GetChildPosition(this, n);
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
