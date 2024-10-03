using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Symbols;
using FormulaEditor.Drawing.Interfaces;

namespace FormulaEditor.Drawing.Symbols
{
    public class PureDrawableSymbol : IDrawableSymbol
    {
        #region Drawable fields
        /// <summary>
        /// The position of the symbol
        /// </summary>
        protected Point position;

        /// <summary>
        /// rectangle of the full symbol size
        /// </summary>
        protected Rectangle fullRectangle;

        /// <summary>
        /// The rectangle of the full relative symbol size
        /// </summary>
        protected Rectangle fullRelativeRectangle;

        /// <summary>
        /// The rectangle of the symbol
        /// </summary>
        protected Rectangle rectangle;

        /// <summary>
        /// The relative rectangle of the symbol
        /// </summary>
        protected Rectangle relativeRectangle;

        /// <summary>
        /// Positions of child formulas
        /// </summary>
        protected Point[] childPositions;

        /// <summary>
        /// The image for mouse moving
        /// </summary>
        protected Image image;

        /// <summary>
        /// The rectangle for inserting before symbol
        /// </summary>
        protected Rectangle insertedRect;

        /// <summary>
        /// Rectangle for show on toolbox
        /// </summary>
        protected Rectangle rectForShow;

        /// <summary>
        /// Position on toolbox
        /// </summary>
        protected Point componentPosition;

        /// <summary>
        /// The rectangle on the component
        /// </summary>
        protected Rectangle componentRectangle;




        #endregion

        /// <summary>
        /// auxiliary variable
        /// </summary>
        public static readonly Pen WhitePen = new Pen(Color.White);

        /// <summary>
        /// auxiliary variable
        /// </summary>
        public static readonly Pen BlackPen = new Pen(Color.Black);


        public static readonly Pen WidePen = new Pen(Color.Black, 2f);



        /// <summary>
        /// The font
        /// </summary>
        protected Font font;


        /// <summary>
        /// Italic fonts
        /// </summary>
        protected static Font[] fontsItalic;

        /// <summary>
        /// Fonts
        /// </summary>
        protected static Font[] fontsBold;

        /// <summary>
        /// Fonts
        /// </summary>
        protected static Font[] fonts;


        protected static Font[] fontsNoBoldItalic;



        /// <summary>
        /// Width shift
        /// </summary>
        public const float W_SHIFT = 0.2f;

        /// <summary>
        /// The height shift
        /// </summary>
        public const float H_SHIFT = 0.0f;

        /// <summary>
        /// The height coefficient
        /// </summary>
        public const float C_HEIGHT = 0.1f;

        /// <summary>
        /// Top shift
        /// </summary>
        public const int TOP_SHIFT = 0;

        /// <summary>
        /// The graphics
        /// </summary>
        public static Graphics Graphics
        {
            get;
            set;
        }

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int widthInsert;


        /// <summary>
        /// The brush of the symbol
        /// </summary>
        public static readonly Brush SymbolBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// The white brush
        /// </summary>
        public static readonly Brush WhiteBrush = new SolidBrush(Color.White);

        /// <summary>
        /// The pen of the line
        /// </summary>
        public static readonly Pen LinePen = new Pen(Color.Black);




        public PureDrawableSymbol()
        {

        }
        /*
                public static Brush SymbolBrush
                {
                    get
                    {
                        return symbolBrush;
                    }
                }*/


        public int WidthInsert
        {
            get
            {
                return widthInsert;
            }
            set
            {
                widthInsert = value;
            }
        }


  
        /// <summary>
        /// Gets height of i - th level
        /// </summary>
        /// <param name="i">the level</param>
        /// <returns>the height</returns>
        public static int GetHeight(int i)
        {
            return fontsBold[i].Height;
        }

        /// <summary>
        /// Gets width of i - th level
        /// </summary>
        /// <param name="i">the level</param>
        /// <returns>the width</returns>
        public static int GetWidth(int i)
        {
            return (int)(Graphics.MeasureString("W", fontsBold[i]).Width * 0.3);
        }

  

        public static Font[] FontsBold
        {
            get
            {
                return fonts;
            }
            set
            {
                if (fonts == null)
                {
                    fonts = value;
                    return;
                }
                if (fonts.Length < value.Length)
                {
                    fonts = value;
                }
            }
        }

        public static Font[] FontsNoBoldItalic
        {
            get
            {
                return fontsNoBoldItalic;
            }
            set
            {
                if (fontsNoBoldItalic == null)
                {
                    fontsNoBoldItalic = value;
                    return;
                }
                if (fontsNoBoldItalic.Length < value.Length)
                {
                    fontsNoBoldItalic = value;
                }
            }
        }


        public static Font[] Fonts
        {
            get
            {
                return fontsBold;
            }
            set
            {
                if (fontsBold == null)
                {
                    fontsBold = value;
                    return;
                }
                if (fontsBold.Length < value.Length)
                {
                    fonts = value;
                }
            }
        }

        public static Font[] FontsItalic
        {
            get
            {
                return fontsItalic;
            }
            set
            {
                if (fontsItalic == null)
                {
                    fontsItalic = value;
                    return;
                }
                if (fontsItalic.Length < value.Length)
                {
                    fontsItalic = value;
                }
            }
        }


        public Point[] ChildPositions
        {
            set
            {
                childPositions = value;
            }
            get
            {
                return childPositions;
            }
        }

        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }

        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public int FullRelativeRectangleX
        {
            set
            {
                fullRelativeRectangle.X = value;
            }
        }
        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public int FullRelativeRectangleY
        {
            set
            {
                fullRelativeRectangle.Y = value;
            }
        }
        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public int FullRelativeRectangleWidth
        {
            set
            {
                fullRelativeRectangle.Width = value;
            }
        }
        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public int FullRelativeRectangleHeight
        {
            set
            {
                fullRelativeRectangle.Height = value;
            }
        }
        public int PositionX
        {
            set
            {
                position.X = value;
            }
        }

        public int PositionY
        {
            set
            {
                position.Y = value;
            }
        }


        public int FullRectangleX
        {
            set
            {
                fullRectangle.X = value;
            }
        }

        public int FullRectangleY
        {
            set
            {
                fullRectangle.Y = value;
            }
        }
        public int FullRectangleWidth
        {
            set
            {
                fullRectangle.Width = value;
            }
        }

        public int FullRectangleHeight
        {
            set
            {
                fullRectangle.Height = value;
            }
        }


        public int InsertedRectX
        {
            set
            {
                insertedRect.X = value;
            }
        }

        public int InsertedRectY
        {
            set
            {
                insertedRect.Y = value;
            }
        }
        public int InsertedRectWidth
        {
            set
            {
                insertedRect.Width = value;
            }
        }

        public int InsertedRectHeight
        {
            set
            {
                insertedRect.Height = value;
            }
        }

        public int RelativeRectangleX
        {
            set
            {
                relativeRectangle.X = value;
            }
        }

        public int RelativeRectangleY
        {
            set
            {
                relativeRectangle.Y = value;
            }
        }
        public int RelativeRectangleWidth
        {
            set
            {
                relativeRectangle.Width = value;
            }
        }

        public int RelativeRectangleHeight
        {
            set
            {
                relativeRectangle.Height = value;
            }
        }


        public int RectangleX
        {
            set
            {
                rectangle.X = value;
            }
        }

        public int RectangleY
        {
            set
            {
                rectangle.Y = value;
            }
        }
        public int RectangleWidth
        {
            set
            {
                rectangle.Width = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }

        public int RectangleHeight
        {
            set
            {
                rectangle.Height = value;
            }
        }




        #region IDrawableSymbol Members


        /// <summary>
        /// Sets location on toolbar
        /// </summary>
        /// <param name="x">the x position</param>
        /// <param name="y">the y position</param>
        public void SetLocationOnTable(int x, int y)
        {
            rectForShow.Location = new Point(x, y);
        }

        public void CalculatePositions()
        {
            // TODO:  Add MathSymbolDrawable.CalculatePositions implementation
        }

        /// <summary>
        /// The symbol full relative rectangle
        /// </summary>
        public Rectangle FullRelativeRectangle
        {
            get
            {
                return fullRelativeRectangle;
            }
        }

        /// <summary>
        /// the symbol full rectangle
        /// </summary>
        public Rectangle FullRectangle
        {
            get
            {
                return fullRectangle;
            }
        }

        /// <summary>
        /// Gets the symbol relative rectangle
        /// </summary>
        public Rectangle RelativeRectangle
        {
            get
            {
                return relativeRectangle;
            }
        }

        /// <summary>
        /// Gets the symbol rectangle
        /// </summary>
        public Rectangle SymbolRectangle
        {
            get
            {
                return rectangle;
            }
        }



        /// <summary>
        /// the rectangle of inserted before symbol
        /// </summary>
        public Rectangle InsertedRect
        {
            get
            {
                return insertedRect;
            }
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public virtual void SetToFormula(MathFormula formula)
        {
            SetToFormulaBase(formula);
        }

        /// <summary>
        /// Base function to setting this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public void SetToFormulaBase(MathFormula formula)
        {
            //base.SetToFormulaBase(formula);
            //level = formula.Level;
            position = new Point();
            fullRectangle = new Rectangle();
            fullRelativeRectangle = new Rectangle();
            rectangle = new Rectangle();
            relativeRectangle = new Rectangle();
            //sizes = formula.Sizes;
            insertedRect = new Rectangle();
            //parent = formula;
        }


        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        public virtual void CalculateFullRelativeRectangle()
        {
            /*if (children != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    this[i].CalculateFullRelativeRectangle();
                }
            }*/
        }

        /// <summary>
        /// Image for mouse motion
        /// </summary>
        public Image SymbolImage
        {
            get
            {
                return image;
            }
        }

        public void SetImage(Image image)
        {
            image.SetControlResolution();
            this.image = image;
        }


        public int StandardWidth
        {
            get
            {
                // TODO:  Add MathSymbolDrawable.StandardWidth getter implementation
                return 0;
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
        public void DrawSelf(Graphics g)
        {
        }


        public void CalculateRelativeRectangle()
        {
            // TODO:  Add MathSymbolDrawable.CalculateRelativeRectangle implementation
        }

        public void CalculateChildPositions()
        {
            // TODO:  Add MathSymbolDrawable.CalculateChildPositions implementation
        }

        public void Prepare(FormulaEditorPerformer performer)
        {
            // TODO:  Add MathSymbolDrawable.Prepare implementation
        }

        public void CalculateRectangleForShow()
        {
            // TODO:  Add MathSymbolDrawable.CalculateRectangleForShow implementation
        }

        /// <summary>
        /// Gets a child position
        /// </summary>
        /// <param name="n">The number of the child</param>
        /// <returns>The position</returns>
        public Point GetChildPosition(int n)
        {
            return (Point)childPositions[n];
        }

        /// <summary>
        /// Rectangle for showing on desktop
        /// </summary>
        public Rectangle RectForShow
        {
            get
            {
                return rectForShow;
            }
            set
            {
                rectForShow.X = value.X;
                rectForShow.Y = value.Y;
                rectForShow.Width = value.Width;
                rectForShow.Height = value.Height;
            }

        }

        /// <summary>
        /// Position on toolbar
        /// </summary>
        public Point ComponentPosition
        {
            set
            {
                componentPosition.X = value.X;
                componentPosition.Y = value.Y;
            }
        }

        /// <summary>
        /// Rectangle on toolbar
        /// </summary>
        public Rectangle ComponentRectangle
        {
            get
            {
                return componentRectangle;
            }
        }


        /// <summary>
        /// Position of the symbol
        /// </summary>
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position.X = value.X;
                position.Y = value.Y;
            }
        }


        /// <summary>
        /// The x coordinate of symbol position
        /// </summary>
        public int X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }

        /// <summary>
        /// The y coordinate of symbol position
        /// </summary>
        public int Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }


        public PureDrawableSymbol PureDrawable
        {
            get
            {
                return null;//pDrawable;
            }
        }




        #endregion

        #region IINsertedObject members



        #endregion
    }
}
