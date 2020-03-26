using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;


using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;

namespace FormulaEditor.Drawing
{
    /// <summary>
    /// Performs all dynamic formula editior operations
    /// </summary>
    public class FormulaEditorPerformer 
    {

        #region Fields

        /// <summary>
        /// Locale formula resources
        /// </summary>
        //static private ResourceSet resources;

        /// <summary>
        /// The pen of line
        /// </summary>
        static private readonly Pen linePen = new Pen(Color.Black);

        /// <summary>
        /// The editor component
        /// </summary>
        private IControl virtualControl;

        /// <summary>
        /// The image of cursor
        /// </summary>
        private Image cursorImage;


        /// <summary>
        /// Formula for editing
        /// </summary>
        protected MathFormulaDrawable formula;

        /// <summary>
        /// Moved symbol
        /// </summary>
        protected MathSymbol movedSymbol = null;

        /// <summary>
        /// New cursor symbol
        /// </summary>
        protected IInsertedObject newCursor = null;

        /// <summary>
        /// Old cursor symbol
        /// </summary>
        protected IInsertedObject oldCursor = null;

        /// <summary>
        /// New cursor remove symbol
        /// </summary>
        protected IInsertedObject newRemoveCursor = null;

        /// <summary>
        /// Old cursor remove symbol
        /// </summary>
        protected IInsertedObject oldRemoveCursor = null;

        /// <summary>
        /// New cursor symbol on toolbox
        /// </summary>
        protected MathSymbol newSymbol = null;


        /// <summary>
        /// Old cursor symbol on toolbox
        /// </summary>
        protected MathSymbol oldSymbol = null;


        /// <summary>
        /// Rectangle for fomula showing
        /// </summary>
        private Rectangle formulaRectangle = new Rectangle();

        /// <summary>
        /// Rectangle of work field
        /// </summary>
        private Rectangle workFieldRectangle = new Rectangle();

        /// <summary>
        /// Symbols on toolbox
        /// </summary>
        private ArrayList symbols = new ArrayList();

        /// <summary>
        /// Color of background
        /// </summary>
        private Color backgroundColor;

        /// <summary>
        /// Color of symbol
        /// </summary>
        private Color symbolColor;

        /// <summary>
        /// The position of the formula
        /// </summary>
        private Point pointFormula = new Point();

        /// <summary>
        /// The point of transition
        /// </summary>
        protected Point transPoint = new Point();

        /// <summary>
        /// The inverted transition point
        /// </summary>
        protected Point invTransPoint = new Point();

        /// <summary>
        /// The relative position of mouse curso 
        /// </summary>
        protected Point imagePoint = new Point(0, 0);

        /// <summary>
        /// The background image
        /// </summary>
        private Image iBkgnd = null;

        /// <summary>
        /// The buffer image
        /// </summary>
        protected Image iTemp = null;

        /// <summary>
        /// The position of the editor
        /// </summary>
        private Point editorPosition = new Point(0, 0);

        /// <summary>
        /// Old mouse x position
        /// </summary>
        protected int oldX;

        /// <summary>
        /// Old mouse y position
        /// </summary>
        protected int oldY;

        /// <summary>
        /// Width of moved image
        /// </summary>
        protected int wImage;

        /// <summary>
        /// Height of moved image
        /// </summary>
        protected int hImage;

        /// <summary>
        /// Flag of on/off mouse listener
        /// </summary>
        //private bool listenerOn = false;

 
        /// <summary>
        /// Brush of symbol
        /// </summary>
        private Brush symbolBrush = null;

        /// <summary>
        /// Brush of background
        /// </summary>
        private Brush backgroundBrush = null;

        /// <summary>
        /// The source rectanglr
        /// </summary>
        private Rectangle sRect = new Rectangle();

        /// <summary>
        /// The destination rectangle
        /// </summary>
        private Rectangle dRect = new Rectangle();

        /// <summary>
        /// The resources of errors
        /// </summary>
        //private static ResourceSet errorResources;

 

        protected IDateTimeSource dateTime;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">component the editor component</param>
        /// <param name="formula">formula the formula for edit</param>
        public FormulaEditorPerformer(IControl control, MathFormulaDrawable formula)
        {
            this.virtualControl = control;
            this.formula = formula;
            newCursor = formula;
       /*     keyPressEventHandler = new KeyPressEventHandler(keyPress);
            keyUpEventHandler = new KeyEventHandler(keyUp);
            keySymbol = this;*/
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">component the editor component</param>
        /// <param name="formula">formula the formula for edit</param>
        /*   public FormulaEditorPerformer(Control control, string formula, int[] sizes)
           {
               this.control = control;
               SetFormula(formula, sizes);
               newCursor = this.formula;
               keyPressEventHandler = new KeyPressEventHandler(keyPress);
               keyUpEventHandler = new KeyEventHandler(keyUp);
               keySymbol = this;
           }*/

        #endregion

        #region Specific Members

        /// <summary>
        /// Date time source
        /// </summary>
        public IDateTimeSource DateTime
        {
            set
            {
                dateTime = value;
            }
        }

  
        /// <summary>
        /// String representation of formula
        /// </summary>
        public string FormulaString
        {
            get
            {
                MathFormula f = new MathFormula(formula, UndrawableConverter.Object);
                return f.FormulaString;
            }
        }


        /// <summary>
        /// Adds symbol to toolbox
        /// </summary>
        /// <param name="symbol">symbol</param>
        public void Add(IDrawableSymbol symbol)
        {
            symbols.Add(symbol);
        }

        /// <summary>
        /// Number of symbols
        /// </summary>
        public int Count
        {
            get
            {
                return symbols.Count;
            }
        }

        /// <summary>
        /// The n th symbol on toolbox
        /// </summary>
        public IDrawableSymbol this[int n]
        {
            get
            {
                return symbols[n] as IDrawableSymbol;
            }
        }

        /// <summary>
        /// Finds symbol
        /// </summary>
        /// <param name="s">Prototype</param>
        /// <returns>Found symbol</returns>
        public MathSymbol Find(MathSymbol s)
        {
            foreach (MathSymbol sym in symbols)
            {
                if (sym.IsSame(s))
                {
                    return sym;
                }
            }
            return null;
        }



        /// <summary>
        /// Sets colors
        /// </summary>
        /// <param name="colBk">colBk the background color</param>
        /// <param name="colSym">colSym the symbol color</param>
        public void SetColors(Color colBk, Color colSym)
        {
            backgroundColor = colBk;
            symbolColor = colSym;
            this.backgroundBrush = new SolidBrush(colBk);
            this.symbolBrush = new SolidBrush(colSym);
        }

        /// <summary>
        /// The edited fomula
        /// </summary>
        public MathFormulaDrawable Formula
        {
            get
            {
                return formula;
            }
            set
            {
                formula = value;
                formula.Position = pointFormula;
                formula.CalculateFullRelativeRectangle();
                formula.CalculatePositions();
                newCursor = formula;
            }
        }


        /// <summary>
        /// Sets a new editing formula
        /// </summary>
        /// <param name="formula">The formula</param>
        /// <param name="rectangle">The new rectangle of new formula</param>
        public void SetFormula(MathFormulaDrawable formula, Rectangle rectangle)
        {
            this.formula = formula;
            newCursor = this.formula;
            Rectangle r = formulaRectangle;
            r.X = rectangle.X;
            r.Y = rectangle.Y;
            r.Width = rectangle.Width;
            r.Height = rectangle.Height;
            Point p = pointFormula;
            p.X = r.X + 20;
            p.Y = r.Y + r.Height / 2;
            this.formula.Position = p;
            this.formula.CalculateFullRelativeRectangle();
            this.formula.CalculatePositions();
        }


        /// <summary>
        /// The formula rectangle
        /// </summary>
        public Rectangle FormulaRectangle
        {
            set
            {
                formulaRectangle.X = value.X;
                formulaRectangle.Y = value.Y;
                formulaRectangle.Width = value.Width;
                formulaRectangle.Height = value.Height;
            }
            get
            {
                return formulaRectangle;
            }
        }

        /// <summary>
        /// The wokfield rectangle
        /// </summary>
        public Rectangle WorkFieldRectangle
        {
            set
            {
                workFieldRectangle.X = value.X;
                workFieldRectangle.Y = value.Y;
                workFieldRectangle.Width = value.Width;
                workFieldRectangle.Height = value.Height;
            }
            get
            {
                return workFieldRectangle;
            }
        }

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="iBkgnd">The background image</param>
        public void Prepare(Image iBkgnd)
        {
            this.iBkgnd = iBkgnd;
            Graphics g = Graphics.FromImage(iBkgnd);
            for (int i = 0; i < Count; i++)
            {
                IDrawableSymbol symbol = this[i];
                DrawSymbol(symbol as MathSymbol, true);
                symbol.Prepare(this);
            }
            Rectangle r = formulaRectangle;
            pointFormula.X = r.X + 20;
            pointFormula.Y = r.Y + r.Height / 2;
            iTemp = new Bitmap(iBkgnd.Width, iBkgnd.Height);
            g = Graphics.FromImage(iTemp);
            g.DrawImage(iBkgnd, 0, 0);
            DrawFormula();
            Bitmap im = new Bitmap(iBkgnd.Width, iBkgnd.Height);
            Brush brush = new SolidBrush(Color.FromArgb(120, 50, 50, 50));
            Graphics gI = Graphics.FromImage(im);
            gI.FillRectangle(brush, 0, 0, im.Width, im.Height);
            cursorImage = im;
        }

        /// <summary>
        /// The editor component
        /// </summary>
        public IControl EditControl
        {
            get
            {
                return virtualControl;
            }
        }

 
        /// <summary>
        /// Draws the formula
        /// </summary>
        public void DrawFormula()
        {
            if (formula == null)
            {
                return;
            }
            Rectangle r = formulaRectangle;
            Graphics g = Graphics.FromImage(iBkgnd);
            g.FillRectangle(backgroundBrush, r.X, r.Y, r.Width, r.Height);
            g.DrawLine(PureDrawableSymbol.LinePen, r.X, r.Y, r.X + r.Width - 1, r.Y);
            g.DrawLine(PureDrawableSymbol.LinePen, r.X + r.Width - 1, r.Y, r.X + r.Width - 1, r.Y + r.Height - 1);
            g.DrawLine(PureDrawableSymbol.LinePen, r.X, r.Y + r.Height - 1, r.X + r.Width - 1, r.Y + r.Height - 1);
            g.DrawLine(PureDrawableSymbol.LinePen, r.X, r.Y + r.Height - 1, r.X, r.Y);
            Point p = pointFormula;
            formula.Position = p;
            formula.CalculateFullRelativeRectangle();
            formula.CalculatePositions();
            formula.Draw(g);
            g.Dispose();
            g = Graphics.FromImage(iTemp);
            sRect.X = r.X;
            sRect.Y = r.Y;
            sRect.Width = r.Width + 1;
            sRect.Height = r.Height + 1;
            g.DrawImage(iBkgnd, sRect, sRect, GraphicsUnit.Pixel);
            g.Dispose();
        }


        /// <summary>
        /// Sets formula
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sizes"></param>
        public void SetFormula(string str, int[] sizes)
        {
            string s = "";
            if (str != null)
            {
                s = str;
            }
            MathFormula f = MathFormula.FromString(sizes, s);
            MathFormulaDrawable form = new MathFormulaDrawable(f, DrawableConverter.Object);
            form.Sizes = sizes;
            formula = form;
            newCursor = form;
            DrawFormula();
        }

        /// <summary>
        /// The choosen symbol
        /// </summary>
        protected MathSymbol choosenSymbol
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    MathSymbol s = this[i] as MathSymbol;
                    IDrawableSymbol ds = s as IDrawableSymbol;
                    if (ds.PureDrawable.RectForShow.Contains(imagePoint))
                    {
                        return s;
                    }
                }
                return null;
            }
        }

        /// <summary>
        ///Draws symbol on tool box 
        /// </summary>
        /// <param name="s">the symbol</param>
        /// <param name="mode">the on/off mode</param>
        protected void DrawSymbol(MathSymbol s, bool mode)
        {
            if (s == null)
            {
                return;
            }
            IDrawableSymbol ds = s as IDrawableSymbol;
            Graphics g = Graphics.FromImage(iBkgnd);
            Color cb, cs;
            Brush bb, bs;

            if (mode)
            {
                cb = backgroundColor;
                cs = symbolColor;
                bb = this.backgroundBrush;
                bs = this.symbolBrush;
            }
            else
            {
                cs = backgroundColor;
                cb = symbolColor;
                bs = this.backgroundBrush;
                bb = this.symbolBrush;
            }
            Rectangle r = ds.PureDrawable.RectForShow;
            g.FillRectangle(bb, r.X, r.Y, r.Width, r.Height);

            Pen linePen = new Pen(Color.Black);
            ds.DrawOnComponent(g, bs, PureDrawableSymbol.LinePen);
            g.DrawLine(linePen, r.X, r.Y, r.X + r.Width - 1, r.Y);
            g.DrawLine(linePen, r.X + r.Width - 1, r.Y, r.X + r.Width - 1, r.Y + r.Height - 1);
            g.DrawLine(linePen, r.X, r.Y + r.Height - 1, r.X + r.Width - 1, r.Y + r.Height - 1);
            g.DrawLine(linePen, r.X, r.Y, r.X, r.Y + r.Height - 1);
            g.Dispose();
        }

        /// <summary>
        /// Shows moved symbol
        /// </summary>
        /// <param name="s">the symbol</param>
        protected void ShowSybmol(MathSymbol s)
        {
            if (s == null)
            {
                return;
            }
            Graphics g = Graphics.FromImage(iTemp);
            IDrawableSymbol ds = s as IDrawableSymbol;
            Rectangle r = ds.PureDrawable.RectForShow;
            sRect.X = r.X;
            sRect.Y = r.Y;
            sRect.Width = r.Width;
            sRect.Height = r.Height;
            g.DrawImage(iBkgnd, sRect, sRect, GraphicsUnit.Pixel);
            g.Dispose();
            g = virtualControl.Graphics;
            Point p = transPoint;
            dRect.X = r.X + p.X;
            dRect.Y = r.Y + p.Y;
            dRect.Width = r.Width;
            dRect.Height = r.Height;
            sRect.X = r.X;
            sRect.Y = r.Y;
            sRect.Width = r.Width;
            sRect.Height = r.Height;
            g.DrawImage(iBkgnd, dRect, sRect, GraphicsUnit.Pixel);
            g.Dispose();
        }

        /// <summary>
        /// Mouse move event handler in move symbol mode
        /// </summary>
        protected void move()
        {
            DrawCursor();
            if (formulaRectangle.Contains(imagePoint))
            {
                newCursor = formula.GetInsertedObject(imagePoint);
            }
            DrawCursor(oldCursor, false, true);
            if (oldCursor != newCursor)
            {
                oldCursor = newCursor;
            }
            DrawCursor(newCursor, true, true);
        }

        /// <summary>
        /// Draws cursor in insert/delete mode
        /// </summary>
        /// <param name="obj">The selected object</param>
        /// <param name="b">The new/old flag</param>
        /// <param name="insert">The insert/delete flag</param>
        protected void DrawCursor(IInsertedObject obj, bool b, bool insert)
        {
            if (obj == null)
            {
                return;
            }
            Rectangle r;
            if (insert)
            {
                r = obj.InsertedRect;
            }
            else
            {
                r = ((IDrawableSymbol)obj).PureDrawable.FullRectangle;
            }
            Image im;
            if (b)
            {
                im = cursorImage;
            }
            else
            {
                im = iBkgnd;
            }
            Graphics g = virtualControl.Graphics;
            Point p = transPoint;
            dRect.X = r.X + p.X;
            dRect.Y = r.Y + p.Y;
            dRect.Width = r.Width;
            dRect.Height = r.Height;
            sRect.X = r.X;
            sRect.Y = r.Y;
            sRect.Width = r.Width;
            sRect.Height = r.Height;
            g.DrawImage(im, dRect, sRect, GraphicsUnit.Pixel);
            g.Dispose();
        }


        /// <summary>
        /// Draws moved cursor
        /// </summary>
        protected void DrawCursor()
        {
            int minX, minY, maxX, maxY;
            Point p = imagePoint;
            if (oldX < p.X)
            {
                minX = oldX;
                maxX = p.X;
            }
            else
            {
                maxX = oldX;
                minX = p.X;
            }
            if (oldY < p.Y)
            {
                minY = oldY;
                maxY = p.Y;
            }
            else
            {
                maxY = oldY;
                minY = p.Y;
            }
            oldX = p.X;
            oldY = p.Y;
            int left = minX - 100;
            int top = minY - 60 - wImage;
            int right = maxX + 100;
            int bottom = maxY + 60 + hImage;
            if (left < 0)
            {
                left = 0;
            }
            if (top < 0)
            {
                top = 0;
            }
            Graphics g = Graphics.FromImage(iTemp);
            sRect.X = left;
            sRect.Y = top;
            sRect.Width = right - left;
            sRect.Height = bottom - top;
            g.DrawImage(iBkgnd, sRect, sRect, GraphicsUnit.Pixel);

            if (movedSymbol != null)
            {
                IDrawableSymbol ds = movedSymbol as IDrawableSymbol;
                Image im = ds.PureDrawable.SymbolImage;
                g.DrawImage(im, p.X - im.Width / 2,
                    p.Y - im.Height - 20);
            }
            g.Dispose();
            Graphics gr = virtualControl.Graphics;
            Point tP = transPoint;
            sRect.X += tP.X;
            sRect.Y += tP.Y;
            dRect.Width = sRect.Width;
            dRect.Height = sRect.Height;
            dRect.X = left + tP.X;
            dRect.Y = top + tP.Y;
            gr.DrawImage(iTemp, dRect, sRect, GraphicsUnit.Pixel);
            gr.Dispose();
        }

        /// <summary>
        /// Draws formula on component
        /// </summary>
        protected void DrawFormulaOnComponent()
        {
            DrawFormula();
            Graphics g = virtualControl.Graphics;
            Rectangle r = formulaRectangle;
            Point tP = transPoint;
            dRect.X = r.X + tP.X;
            dRect.Y = r.Y + tP.Y;
            dRect.Width = r.Width + 1;
            dRect.Height = r.Height + 1;
            sRect.X = r.X;
            sRect.Y = r.Y;
            sRect.Width = r.Width + 1;
            sRect.Height = r.Height + 1;
            g.DrawImage(iBkgnd, dRect, sRect, GraphicsUnit.Pixel);
            g.Dispose();

        }
        /// <summary>
        /// Initial drawing
        /// </summary>
        public void DrawInit()
        {
            DrawFormulaOnComponent();
        }

        #endregion

    }
}
