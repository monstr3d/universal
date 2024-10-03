using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Factory of series painter
    /// </summary>
    public interface ISeriesPainterFactory
    {
        ISeriesPainter this[object key] { get; }
    }
}
