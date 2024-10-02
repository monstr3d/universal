using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Interfaces
{
    /// <summary>
    /// Event output collection
    /// </summary>
    public interface IEventOutput
    {
        /// <summary>
        /// Dictionary of event output
        /// </summary>
        Dictionary<string, List<string>> EventOutput
        {
            get;
        }
    }
}
