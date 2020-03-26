using System;
using System.Collections.Generic;
using System.Text;

using Chart;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Factory;

namespace DataPerformer.UI
{
    /// <summary>
    /// Simple point collection chooser factory
    /// </summary>
    public class SimplePointCollectionChooserFactory : PointCollectionChooserFactory
    {
        /// <summary>
        /// Names of choosers
        /// </summary>
        public static readonly string[] names = new string[] { "Colored circles" };

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly SimplePointCollectionChooserFactory Object =
            new SimplePointCollectionChooserFactory();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected SimplePointCollectionChooserFactory()
        {
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        public override string[] Names
        {
            get 
            { 
                return names; 
            }
        }


        /// <summary>
        /// Gets points collection chooser by point factory
        /// </summary>
        /// <param name="factory">The point factory</param>
        /// <returns>The chooser</returns>
        public override IPointCollecionChooser this[IPointFactory factory]
        {
            get 
            {
                if (factory is CirclePointFactory)
                {
                    return new ColoredChooser();
                }
                return null; 
            }
        }

        /// <summary>
        /// Sets itself as factory
        /// </summary>
        public static void Set()
        {
            PointCollectionChooserFactory.Factory = Object;
        }
    }
}
