using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Chart.Interfaces
{
    /// <summary>
    /// Creator of chart properties
    /// </summary>
    public interface IChartProperiesFormCreator
    {
        /// <summary>
        /// Creates form
        /// </summary>
        /// <returns></returns>
        Form Create();
    }
}
