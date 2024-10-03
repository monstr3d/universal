using System;
using System.Collections.Generic;
using System.Text;


using Chart;
using Chart.Drawing.Interfaces;

namespace DataPerformer.UI
{
    /// <summary>
    /// Factory for points' coolection chooser
    /// </summary>
    public abstract class PointCollectionChooserFactory
    {
        static PointCollectionChooserFactory factory;

        /// <summary>
        /// Gets points collection chooser by point factory
        /// </summary>
        /// <param name="factory">The point factory</param>
        /// <returns>The chooser</returns>
        public abstract IPointCollecionChooser this[IPointFactory factory]
        {
            get;
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        public abstract string[] Names
        {
            get;
        }

        /// <summary>
        /// Base factory
        /// </summary>
        static public PointCollectionChooserFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }
    }
}
