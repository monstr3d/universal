using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Palette button
    /// </summary>
    public interface IPaletteButton
    {
        /// <summary>
        /// Number of image
        /// </summary>
        int ImageNumber
        {
            get;
        }


        /// <summary>
        /// The type
        /// </summary>
        string Type
        {
            get;
        }

        /// <summary>
        /// The "is arrow" flag
        /// </summary>
        bool IsArrow
        {
            get;
        }


        /// <summary>
        /// The kind
        /// </summary>
        string Kind
        {
            get;
        }

        /// <summary>
        /// The image
        /// </summary>
        object ButtonImage
        {
            get;
        }

        /// <summary>
        /// Object type
        /// </summary>
        Type ReflectionType
        {
            get;
        }

        /// <summary>
        /// Tooltip text
        /// </summary>
        string ToolTip
        {
            get;
        }

    }
}
