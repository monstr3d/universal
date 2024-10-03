using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Drawing
{
    public static class StaticExtensionFormulaEditorDrawing
    {
        /// <summary>
        /// Sets control resolution
        /// </summary>
        /// <param name="image">Image to set</param>
        public static void SetControlResolution(this Image image)
        {
            Graphics g = PureDrawableSymbol.Graphics;
            (image as Bitmap).SetResolution(g.DpiX, g.DpiY);
        }

        /// <summary>
        /// Prepares graphics
        /// </summary>
        /// <param name="g">Graphics for preparation</param>
        public static void Prepare(this Graphics g)
        {
            PureDrawableSymbol.Graphics = g;
            int[] sizes = MathSymbolFactory.Sizes;
            SimpleSymbolDrawable.Prepare(sizes, g);
            BracketsSymbolDrawable.Prepare(sizes, g);
            AbsSymbolDrawable.Prepare(sizes, g);
        }
    }
}
