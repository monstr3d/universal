using System;
using System.Collections.Generic;
using System.Text;

using DataPerformer;
using DataPerformer.Interfaces;


namespace DataPerformer.UI
{
    /// <summary>
    /// Chooser of points' collection
    /// </summary>
    public interface IPointCollecionChooser
    {
        /// <summary>
        /// List of names of measurements
        /// </summary>
        List<string> Measurements
        {
            get;
            set;
        }

        /// <summary>
        /// Data consumer
        /// </summary>
        IDataConsumer Consumer
        {
            set;
        }
    }
}
