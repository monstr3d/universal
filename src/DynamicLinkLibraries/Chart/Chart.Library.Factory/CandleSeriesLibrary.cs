using System.Drawing;
using System;

using BaseTypes;

using DataPerformer.Interfaces;

using Chart.Drawing;
using Chart.Drawing.Interfaces;
using Chart.Library.Painters;

namespace Chart.Library.Factory
{
    public class CandleSeriesLibrary : ISeriesPainterFactory
    {

        public CandleSeriesLibrary() 
        {

            this.Add();
        }

        ISeriesPainter ISeriesPainterFactory.this[object key]
        {
            get
            {
                if (!(key is Tuple<ISeries, Color[], ChartPerformer, object>))
                {
                    return null;
                }
                var t = key as Tuple<ISeries, Color[], ChartPerformer, object>;
                if (!(t.Item4 is IMeasurement))
                {
                    return null;
                }
                var m = t.Item4 as IMeasurement;
                var type = m.Type;
                if (!(type is ArrayReturnType)) { return null; }
                ArrayReturnType at = type as ArrayReturnType;
                if (!at.ElementType.Equals((double)0)) { return null; }
                var d = at.Dimension;
                if (d is int[])
                {
                    if ((d as int[]) [0] == 4)
                    {
                        return new CandleSeriesPainter();
                    }
                }
                return null;
            }
        }
    }
}
