using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database.Interfaces
{
    /// <summary>
    /// Change of log item
    /// </summary>
    public interface IChangeLogItem
    {

        /// <summary>
        /// Change log item
        /// </summary>
        event Action<ILogItem> Change;
    }
}
