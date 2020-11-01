using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionChartDrawing
    {
        /// <summary>
        /// Gets argument position
        /// </summary>
        /// <param name="series">The series</param>
        /// <param name="argument">The argument</param>
        /// <returns>The position</returns>
        public static int GetArgumentPosition(this ISeries series, double argument)
        {
            int i = 0;
            foreach (var point in series.Points)
            {
                if (point.X > argument)
                {
                    break;
                }
                ++i;
            }
            return i;
        }
    }
}
