using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database.Interfaces
{
    /// <summary>
    /// Log direcrory
    /// </summary>
    public interface ILogDirectory : ILogItem
    {
        /// <summary>
        /// Children
        /// </summary>
        IEnumerable<ILogItem> Children
        {
            get;
        }

    }
}
