using Event.Log.Database.Interfaces;

namespace Event.Log.Database
{
    public class LogIntervalWrapper : LogItemWrapper, ILogInterval
    {
        #region Filds

        ILogInterval interval;

        ILogData data;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        public LogIntervalWrapper(ILogInterval item)
        {
            interval = item;
            this.item = item as ILogData;
            StaticExtensionEventLogDatabase.items[(item as ILogItem).Id] = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Parent</param>
        public LogIntervalWrapper(LogDirectoryWrapper parent, ILogInterval interval, ILogData data) :
            this(interval)
        {
            this.parent = parent;
            parent.items.Add(this);
            this.data = data;
        }

        #region Implementation of interfaces

        uint ILogInterval.Begin
        {
            get
            {
                return interval.Begin;
            }
            set
            {
                interval.Begin = value;
            }
        }

        ILogData ILogInterval.Data
        {
            get
            {
                return data;
            }
        }

        object ILogInterval.DataId
        {
            get
            {
                return interval.DataId;
            }
        }

        uint ILogInterval.End
        {
            get
            {
                return interval.End;
            }
            set
            {
                interval.End = value;
            }

        }

        internal ILogData DataSet
        {
            set
            {
                data = value;
            }
        }


        /// <summary>
        /// Name of file
        /// </summary>
        public override string FileName
        {
            get
            {
                return data.FileName;
            }
        }

        #endregion
    }
}
