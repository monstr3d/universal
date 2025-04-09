using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database
{
    public class LogItemWrapper : ILogData, IParentSet
    {
        #region Fields

        protected ILogData item;

        internal List<ILogItem> items = new List<ILogItem>();

        protected ILogItem parent;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        public LogItemWrapper(ILogData item)
        {
            this.item = item;
            StaticExtensionEventLogDatabase.items[item.Id] = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Parent</param>
        public LogItemWrapper(LogDirectoryWrapper parent, ILogData item)
        {
            this.item = item;
            this.parent = parent;
            parent.items.Add(this);
            StaticExtensionEventLogDatabase.items[item.Id] = this;
        }

        /// <summary>
        /// Default constructor for subcalasses
        /// </summary>
        protected LogItemWrapper()
        {

        }

        #endregion

        #region Interface Implementation

        string ILogItem.Comment
        {
            get
            {
                return item.Comment;
            }

            set
            {
                item.Comment = value;
            }
        }

        DateTime ILogItem.DateTime
        {
            get
            {
                return item.DateTime;
            }
        }

        object ILogItem.Id
        {
            get
            {
                return item.Id;
            }
        }

        string ILogItem.Name
        {
            get
            {
                return item.Name;
            }

            set
            {
                if ((parent as ILogDirectory).GetDirectoryNames().Contains(value))
                {
                    throw new ErrorHandler.OwnException(value + " already exists");
                }
                item.Name = value;
            }
        }

        object ILogItem.ParentId
        {
            get
            {
                return item.ParentId;
            }
            set
            {
                item.ParentId = value;
            }
        }

        ILogItem ILogItem.Parent
        {
            get
            {
                return parent;
            }
            set
            {

            }
        }

        /// <summary>
        /// Name of file
        /// </summary>
        public virtual string FileName
        {
            get
            {
                return item.FileName;
            }
        }

        int ILogData.Type
        {
            get
            {
                return item.Type;
            }

            set
            {
                item.Type = value;
            }
        }

        int ILogData.Length
        {
            get
            {
                return item.Length;
            }
        }

        IEnumerable<byte[]> ILogData.Create(uint begin, uint end)
        {
            return item.Create(begin, end);
        }

        void ILogItem.Delete()
        {
            item.Delete();
            StaticExtensionEventLogDatabase.items.Remove(item.Id);
            StaticExtensionEventLogDatabase.Data.Filenames.Remove(item.Name);
            (parent as LogDirectoryWrapper).items.Remove(this);
        }

        #endregion

        ILogItem IParentSet.Parent
        {
            set
            {
                parent = value;
                (parent as LogDirectoryWrapper).items.Add(this);
            }
        }
    }
}