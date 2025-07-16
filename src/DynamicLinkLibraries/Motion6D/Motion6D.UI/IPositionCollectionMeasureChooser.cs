using System.Collections.Generic;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;

namespace Motion6D.UI
{
    /// <summary>
    /// Chooser of position collection
    /// </summary>
    public interface IPositionCollectionMeasureChooser
    {
        /// <summary>
        /// List of measurements
        /// </summary>
        List<string> Meausements
        {
            get;
            set;
        }

        /// <summary>
        /// Data consumer
        /// </summary>
        IDataConsumer Consumer
        {
            get;
            set;
        }

        /// <summary>
        /// Selects chooser by position factory
        /// </summary>
        /// <param name="factory">The position factory</param>
        /// <returns>The chooser</returns>
        IPositionCollectionMeasureChooser this[IPositionFactory factory]
        {
            get;
        }

         
    }
}
