using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Xml.Drawing.Library.Classes
{
    /// <summary>
    /// Structure which contains relevant graphics elements
    /// </summary>
    public class GraphicsStructure
    {
        #region Fields

        Font font;

        Brush foregroundBrush;

        Brush backgroundBrush;

        Pen pen;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="font">Font</param>
        /// <param name="foregroundBrush">Foreground brush</param>
        /// <param name="backgroundBrush">Background brush</param>
        /// <param name="pen">Pen</param>
        public GraphicsStructure(Font font, Brush foregroundBrush, Brush backgroundBrush, Pen pen)
        {
            this.font = font;
            this.foregroundBrush = foregroundBrush;
            this.backgroundBrush = backgroundBrush;
            this.pen = pen;
        }


        #endregion

        #region Members

        /// <summary>
        /// Font
        /// </summary>
        public Font Font
        {
            get
            {
                return font;
            }
        }

        /// <summary>
        /// Foreground brush
        /// </summary>
        public Brush ForegroundBrush
        {
            get
            {
                return foregroundBrush;
            }
        }

        /// <summary>
        /// Background brush
        /// </summary>
        public Brush BackgroundBrush
        {
            get
            {
                return backgroundBrush;
            }
        }

        /// <summary>
        /// Pen
        /// </summary>
        public Pen Pen   
        {
            get
            {
                return pen;
            }
        }


        #endregion
    }
}
