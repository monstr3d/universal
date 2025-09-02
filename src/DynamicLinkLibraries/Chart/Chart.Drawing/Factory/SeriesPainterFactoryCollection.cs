using System.Collections.Generic;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing.Factory
{
    /// <summary>
    /// Collection of factories
    /// </summary>
    public class SeriesPainterFactoryCollection : ISeriesPainterFactory
    {
        List<ISeriesPainterFactory> list = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public SeriesPainterFactoryCollection()
        {


        }

        /// <summary>
        /// Adds a facoty
        /// </summary>
        /// <param name="factory">The facory to add</param>
        public void Add(ISeriesPainterFactory factory)
        {
            list.Add(factory);
        }

        ISeriesPainter ISeriesPainterFactory.this[object key]
        {
            get
            {
                foreach (ISeriesPainterFactory factory in list)
                {
                    var f = factory[key];
                    if (f != null)
                    {
                        return f;
                    }
                }
                return null;
            }
        }
    }
}