using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Interfaces
{
    public interface IPointFactoryExtended : IPointFactory
    {
        /// <summary>
        /// Gets painter
        /// </summary>
        /// <param name="performer">Performer of charts</param>
        /// <returns>A painter</returns>
        ISeriesPainter GetPainter(ChartPerformer performer);

    }
}
