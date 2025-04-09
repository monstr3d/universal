using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database
{
    /// <summary>
    /// Wrapper of directory
    /// </summary>
    public class LogDirectoryWrapper : ILogDirectory, IParentSet
    {
        #region Fields

        ILogItem item;

        internal List<ILogItem> items = new List<ILogItem>();

        ILogItem parent;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        public LogDirectoryWrapper(ILogItem item)
        {
            this.item = item;
            StaticExtensionEventLogDatabase.items[item.Id] = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Parent</param>
        public LogDirectoryWrapper(LogDirectoryWrapper parent, ILogItem item)
        {
            this.item = item;
            this.parent = parent;
            parent.items.Add(this);
            StaticExtensionEventLogDatabase.items[item.Id] = this;
        }

        #endregion

        #region Interface Implementation

        IEnumerable<ILogItem> ILogDirectory.Children
        {
            get
            {
                return items;
            }
        }

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

        ILogItem IParentSet.Parent
        {
            set
            {
                parent = value;
                (parent as LogDirectoryWrapper).items.Add(this);
            }
        }

        void ILogItem.Delete()
        {
            List<ILogItem> its = new List<ILogItem>(items);
            foreach (ILogItem it in its)
            {
                it.Delete();
            }
            item.Delete();
            if (parent != null)
            {
                (parent as LogDirectoryWrapper).items.Remove(this);
            }
            StaticExtensionEventLogDatabase.items.Remove(item.Id);
        }

        #endregion

    }
}