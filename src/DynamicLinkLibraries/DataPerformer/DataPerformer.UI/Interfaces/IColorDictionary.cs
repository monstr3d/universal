using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
