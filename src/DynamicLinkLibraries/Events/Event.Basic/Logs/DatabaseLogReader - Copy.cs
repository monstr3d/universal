using DataPerformer.Interfaces;
using Event.Interfaces;
using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Basic.Logs
{
    /// <summary>
    /// Log reader from database
    /// </summary>
    class DatabaseLogReader : ILogReader, IChangeLogItem
    {

        #region Fields

        internal ILogData log;

        event Action<ILogItem> change = (ILogItem item) => { };

        string calcReason;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log">Log</param>
        internal DatabaseLogReader(ILogData log)
        {
            this.log = log;
        }

        #endregion


        event Action<ILogItem> IChangeLogItem.Change
        {
            add
            {
                change += value;
            }

            remove
            {
                change -= value;
            }
        }


        #region ILogReader Members

        int ILogReader.FullLength
        {
            get
            {
                return log.Length;
            }
        }

        string ILogReader.Name
        {
            get
            {
                return log.Name;
            }
        }

        string ILogReader.FileName
        {
            get
            {
                return log.FileName;
            }
        }

        IEnumerable<object> ILogReader.Load(uint begin, uint end)
        {
            change(log);
            return log.Create(begin, end).FromBytes();
        }

        #endregion
 
    }
}
