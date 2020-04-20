using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FormulaEditor.Drawing.Symbols;

namespace FormulaEditor.Drawing.Interfaces
{
    /// <summary>
    /// Summary description for FormulaEditor.
    /// </summary>
    public interface IInsertedObject
    {

        /// <summary>
        /// The rectangle for insetring
        /// </summary>
        Rectangle InsertedRect
        {
            get;
        }


    }


    /// <summary>
    /// Drawable symbol
    /// </summary>
    public interface IDrawableSymbol : IInsertedObject
    {

        /// <summary>
        /// Sets location on toolbar
        /// </summary>
        /// <param name="x">the x position</param>
        /// <param name="y">the y position</param>
        //void SetLocationOnTable(int x, int y);


        /// <summary>
        /// Calculates positions of all children
        /// </summary>
        void CalculatePositions();

        /// <summary>
        /// Calculates full relative rectangle
        /// </summary>
        void CalculateFullRelativeRectangle();

        /// <summary>
        /// Standard width of symbol
        /// </summary>
        int StandardWidth
        {
            get;
        }

        /// <summary>
        /// Draws symbol on toolbox
        /// </summary>
        /// <param name="g">the graphics for draw</param>
        /// <param name="brush">Drawing brush</param>
        /// <param name="pen">Drawing pen</param>
        void DrawOnComponent(Graphics g, Brush brush, Pen pen);

        /// <summary>
        /// Draws the symbol without children
        /// </summary>
        /// <param name="g">the graphics for draw</param>
        void DrawSelf(Graphics g);

        /// <summary>
        /// Calculates relative rectangle
        /// </summary>
        void CalculateRelativeRectangle();

        /// <summary>
        /// Calculaltes child formulas positions
        /// </summary>
        void CalculateChildPositions();

        /// <summary>
        /// Prepare to set on toolbar
        /// </summary>
        /// <param name="performer">the editor preformer</param>
        void Prepare(FormulaEditorPerformer performer);

        /**
        * Calculates rectangle for show on toolbox
        */
        void CalculateRectangleForShow();

        /// <summary>
        /// Pure drawable component
        /// </summary>
        PureDrawableSymbol PureDrawable
        {
            get;
        }
    }
}
