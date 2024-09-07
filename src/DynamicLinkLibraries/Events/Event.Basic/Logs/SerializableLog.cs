using Event.Interfaces;


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
