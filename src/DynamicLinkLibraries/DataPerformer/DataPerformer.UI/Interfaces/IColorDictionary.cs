using System.Collections.Generic;
using System.Drawing;

namespace DataPerformer.UI.Interfaces
{
    /// <summary>
    /// Color dictionary
    /// </summary>
    public interface IColorDictionary
    {
        /// <summary>
        /// Color dictionary
        /// </summary>
        Dictionary<string, Dictionary<string, Color>> ColorDictionary
        { get; set; }
    }
}
