using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI
{
    /// <summary>
    /// The toolbar of objects' and arrows' buttons
    /// </summary>
    public class PaletteToolBar : ToolBar
    {
        /// <summary>
        /// The tools diagram
        /// </summary>
        private ToolsDiagram diagram;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="diagram">The tools diagram</param>
        public PaletteToolBar(ToolsDiagram diagram)
        {
            this.diagram = diagram;
            this.ButtonClick += diagram.ClickEventHandler;
        }

        /// <summary>
        /// The tools diagram
        /// </summary>
        public ToolsDiagram ToolDiagram
        {
            get
            {
                return diagram;
            }
        }

    }
}
