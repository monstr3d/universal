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
        /// Gets painter
        /// </summary>
        /// <param name="factory">The factoryparam>
        /// <param name="performer">Performer of charts</param>
        /// <returns>A painter</returns>
        public static ISeriesPainter GetPainter(this IPointFactory factory, ChartPerformer performer)
        {
            if (!(factory is IPointFactoryExtended))
            {
                throw new Exception("Factory does not support series painter");
            }
            return (factory as IPointFactoryExtended).GetPainter(performer);
        }
    }
}
