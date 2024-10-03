using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Diagram.UI.Operations
{
    /// <summary>
    /// Common operations with framework
    /// </summary>
    public static class CommonOperations
    {
        /// <summary>
        /// Creates Arrow Control
        /// </summary>
        /// <param name="control">Base Control</param>
        /// <param name="tools">Tools</param>
        public static void CreateArrowControl(Control control, ToolsDiagram tools)
        {
            PaletteToolBar toolBar = new PaletteToolBar(tools);
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(35, 35);
            imageList.Images.Add(ResourceImage._object);
            imageList.Images.Add(ResourceImage.Arrow);
            toolBar.ImageList = imageList;
            toolBar.ImageList = imageList;

            PaletteButton p = new PaletteButton(toolBar, null, null, "", "Selection arrow", imageList.Images[0], 0, true);
            p.Visible = false;

            new PaletteButton(toolBar, null, null, "", "Selection arrow", imageList.Images[1], 1, true);
            control.Controls.Add(toolBar);
        }
    }
}
