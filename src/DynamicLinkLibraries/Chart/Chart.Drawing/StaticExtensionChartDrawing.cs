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
        /// Gets series from the chart performer
        /// </summary>
        /// <param name="performer">The chart performer</param>
        /// <returns>The series</returns>
        public static IEnumerable<ISeries> GetSeries(this ChartPerformer performer)
        {
            int n = performer.Count;
            for (int i = 0; i < n; i++)
            {
                yield return performer[i];
            }
        }
        
        /// <summary>
        /// Factory
        /// </summary>
        public static ISeriesPainterFactory SeriesPainterFactory { get; set; }


        /// <summary>
        /// Preparation of Chart performer
        /// </summary>
        public static IChartPerformerPreparation ChartPerformerPreparation
        {
            get;
            set;
        }

        /// <summary>
        /// Preparation of chart performer
        /// </summary>
        /// <param name="performer"></param>
        /// <param name="obj"></param>
        public static void PrepareChartPerformer(this ChartPerformer performer, object obj)
        {
            if (ChartPerformerPreparation == null)
            {
                return;
            }
            ChartPerformerPreparation.Prepare(performer, obj);
        }

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

        /// <summary>
        /// Gets series painter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ISeriesPainter ToSeriesPainter(this object obj)
        {
            if (SeriesPainterFactory == null)
            {
                return null;
            }
            if (obj == null)
            {
                return null;
            }
            return SeriesPainterFactory[obj];
        }
    }
}
