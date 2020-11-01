using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DataPerformer.UI.Interfaces
{
    /// <summary>
    /// UI Label of Chart
    /// </summary>
    public interface IGraphLabel
    {
        /// <summary>
        /// Data
        /// </summary>
        Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
           Dictionary<string, string>, string[], int[],
            Tuple<double[],
           Dictionary<string, Dictionary<string,
           Tuple<Color[], bool, double[]>>>>[]> Data
        {
            get;
            set;
        }

    }
}
