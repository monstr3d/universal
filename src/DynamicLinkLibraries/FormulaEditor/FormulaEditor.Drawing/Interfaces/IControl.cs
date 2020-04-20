using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FormulaEditor.Drawing.Interfaces
{
    public interface IControl
    {
        /// <summary>
        /// Graphics
        /// </summary>
        Graphics Graphics
        {
            get;
        }
    }
}
