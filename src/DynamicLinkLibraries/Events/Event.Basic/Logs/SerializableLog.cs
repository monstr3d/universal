using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Event.Interfaces;

using Event.Portable;

namespace Event.Basic.Logs
{
    /// <summary>
    /// Log with serialization
    /// </summary>
    public class SerializableLog : MemoryLog, ISaveLog
    {
        /// <summary>
        /// New log
        /// </summary>
        public override IEventLog NewLog
        {
            get
            {
                return new SerializableLog();
            }
        }

        byte[] ISaveLog.Bytes
        {
            get
            {
                return list.LogListToBytes();
            }
            set
            {
                list = value.LogListFromBytes();
            }
        }

        string ISaveLog.Extension
        {
            get
            {
                return "serializable";
            }
        }

        #region Own Members

        


        #endregion

    }
}
