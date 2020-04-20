using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor.Drawing
{
    /// <summary>
    /// Drawable formula
    /// </summary>
    public class MathFormulaDrawable : MathFormula, IInsertedObject
    {

        /// <summary>
        /// The relation between end symbol and and space
        /// </summary>
        private const float RELATION = 0.5f;


        /// <summary>
        /// The position of the formula
        /// </summary>
        private Point position = new Point();

        /// <summary>
        /// Auxiliary position of current symbol
        /// </summary>
        private Point tempPosition = new Point();

        /// <summary>
        /// Rectangle at the end of formula
        /// </summary>
        private Rectangle endRectangle = new Rectangle();


        /// <summary>
        /// Relative rectangle of formula size
        /// </summary>
        private Rectangle fullRelativeRectangle = new Rectangle();


        public MathFormulaDrawable(MathFormula formula, IMathSymbolConverter converter)
            : base(formula.Level, formula.Sizes)
        {
            sizes = formula.Sizes;
            for (int i = 0; i < formula.Count; i++)
            {
                MathSymbol s = formula[i];
                MathSymbol sym = converter.Convert(s);
                sym.Sizes = sizes;
                sym.Append(this);
                sym = Last;
                for (int j = 0; j < s.Count; j++)
                {
                    if (j >= sym.Count)
                    {
                        break;
                    }
                    if (s[j] != null)
                    {
                        s[j].Sizes = sizes;
                        sym[j] = new MathFormulaDrawable(s[j], converter);
                    }
                }
            }
        }

        /// <summary>
        /// Copies this formula
        /// </summary>
        /// <returns>the copy</returns>
        public override MathFormula Copy()
        {
            form = new MathFormulaDrawable(new MathFormula(level, sizes), DrawableConverter.Object);
            for (int i = 0; i < Count; i++)
            {
                MathSymbol s = this[i].Copy();
                s.Parent = form;
                form.Add(s);
            }
            return form;
        }


        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">graphics for drawing</param>
        public void Draw(Graphics g)
        {
            for (int i = 0; i < Count; i++)
            {
                IDrawableSymbol sym = this[i] as IDrawableSymbol;
                MathSymbolDrawable.Draw(sym as MathSymbol, g);
            }
        }
        /// <summary>
        /// Calculates full relative rectangle of the formula
        /// </summary>
        public virtual void CalculateFullRelativeRectangle()
        {
            IDrawableSymbol symbol = null;
            int up = 0, down = 0, width = 0;
            for (int i = 0; i < Count; i++)
            {
                symbol = this[i] as IDrawableSymbol;
                symbol.CalculateFullRelativeRectangle();
                Rectangle r = symbol.PureDrawable.FullRelativeRectangle;
                int w = r.Width;
                if (r.Y < up)
                {
                    up = r.Y;
                }
                if (r.X + r.Height > down)
                {
                    down = r.X + r.Height;
                }
                width += w;
            }
            if (symbol == null)
            {
                fullRelativeRectangle.X = 0;
                fullRelativeRectangle.Y = -PureDrawableSymbol.GetHeight(level) / 2;
                fullRelativeRectangle.Width = PureDrawableSymbol.GetWidth(level);
                fullRelativeRectangle.Height = PureDrawableSymbol.GetHeight(level);
                return;
            }
            fullRelativeRectangle.X = 0;
            fullRelativeRectangle.Y = up;
            fullRelativeRectangle.Width = width;
            fullRelativeRectangle.Height = down - up;
        }



        /// <summary>
        /// the end rectangle of the formula
        /// </summary>
        public Rectangle EndRectangle
        {
            get
            {
                return endRectangle;
            }
        }

        /// <summary>
        /// Gets the symbol for removing by mouse click 
        /// </summary>
        /// <param name="p">the mouse position</param>
        /// <returns>the symbol for removing by mouse click</returns>
        public IDrawableSymbol GetRemovedSymbol(Point p)
        {
            for (int i = 0; i < Count; i++)
            {
                MathSymbol symbol = this[i];
                IDrawableSymbol ret = MathSymbolDrawable.GetRemovedSymbol(symbol, p);
                if (ret != null)
                {
                    return ret;
                }
            }
            return null;
        }




        /// <summary>
        /// Full rectangle of formula size
        /// </summary>
        public Rectangle FullRelativeRectangle
        {
            get
            {
                return fullRelativeRectangle;
            }
        }

        /// <summary>
        /// Calculates positions of formula symbols
        /// </summary>
        public void CalculatePositions()
        {
            tempPosition.X = position.X;
            tempPosition.Y = position.Y;
            IDrawableSymbol symbol = null;
            //int up = 0, down = 0, width = 0;
            for (int i = 0; i < Count; i++)
            {
                symbol = this[i] as IDrawableSymbol;
                symbol.PureDrawable.X = tempPosition.X;
                symbol.PureDrawable.Y = tempPosition.Y;
                symbol.CalculatePositions();
                Rectangle r = symbol.PureDrawable.FullRelativeRectangle;
                int w = r.Width;
                tempPosition.X += w;
            }
            if (symbol == null)
            {
                endRectangle.X = position.X;
                int h = PureDrawableSymbol.GetHeight(level);
                endRectangle.Y = position.Y - h / 2;
                endRectangle.Height = h;
                int w = (int)(((float)h) * RELATION);
                endRectangle.Width = w;
                return;
            }
            endRectangle.Width = symbol.PureDrawable.FullRectangle.Width;
            endRectangle.Height = symbol.PureDrawable.FullRectangle.Height;
            endRectangle.X = tempPosition.X;
            int H = symbol.PureDrawable.RelativeRectangle.Height;
            int W = (int)(((float)H) * RELATION);
            endRectangle.Width = W;
            endRectangle.Y = tempPosition.Y - H / 2;
        }
        #region IInsertedObject Members


        /// <summary>
        /// Gets object to insert
        /// </summary>
        /// <param name="p">position of the object</param>
        /// <returns>The object</returns>
        public IInsertedObject GetInsertedObject(Point p)
        {
            for (int i = 0; i < Count; i++)
            {
                MathSymbol find = this[i];
                IInsertedObject obj = MathSymbolDrawable.GetInsertedObject(find, p);
                if (obj != null)
                {
                    return obj;
                }
            }
            if (endRectangle.Contains(p))
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Iserted symbol rectangle
        /// </summary>
        public Rectangle InsertedRect
        {
            get
            {
                return endRectangle;
            }
        }


        #endregion

        /// <summary>
        /// The formula position
        /// </summary>
        public Point Position
        {
            set
            {
                position.X = value.X;
                position.Y = value.Y;
            }
            get
            {
                return position;
            }
        }
    }
}
