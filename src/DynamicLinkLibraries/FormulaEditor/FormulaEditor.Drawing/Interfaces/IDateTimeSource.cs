using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Drawing.Interfaces
{
    /// <summary>
    /// Source of date time
    /// </summary>
    public interface IDateTimeSource
    {
        /// <summary>
        /// The date time
        /// </summary>
        DateTime DateTime
        {
            get;
        }
    }
}
