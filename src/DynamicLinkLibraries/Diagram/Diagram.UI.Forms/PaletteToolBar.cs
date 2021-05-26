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
    public class PaletteToolBar : ToolStrip
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
            ItemClicked += diagram.BtnCkick;
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
