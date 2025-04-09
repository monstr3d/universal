using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces.BufferedData.Interfaces;

namespace DataPerformer.Interfaces.BufferedData
{
    /// <summary>
    /// Wrapper of directory
    /// </summary>
    public class BufferDirectoryWrapper : IBufferDirectory, IParentSet
    {
        #region Fields

        IBufferItem item;

        internal List<IBufferItem> items = new List<IBufferItem>();

        IBufferItem parent;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        public BufferDirectoryWrapper(IBufferItem item)
        {
           this.item = item;
           StaticExtensionDataPerformerInterfaces.items[item.Id] = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Parent</param>
        public BufferDirectoryWrapper(BufferDirectoryWrapper parent, IBufferItem item)
        {
            this.item = item;
            this.parent = parent;
            parent.items.Add(this);
           StaticExtensionDataPerformerInterfaces.items[item.Id] = this;
        }

        #endregion

        #region Interface Implementation

        IEnumerable<IBufferItem> IBufferDirectory.Children
        {
            get
            {
                return items;
            }
        }

        string IBufferItem.Comment
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

        object IBufferItem.Id
        {
            get
            {
                return item.Id;
            }
        }

        string IBufferItem.Name
        {
            get
            {
               return item.Name;
            }

            set
            {
                if ((parent as IBufferDirectory).GetDirectoryNames().Contains(value))
                {
                    throw new ErrorHandler.OwnException(value + " already exists");
                }
                item.Name = value;
            }
        }

        object IBufferItem.ParentId
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

        IBufferItem IBufferItem.Parent
        {
            get
            {
                return parent;
            }
            set
            {

            }
        }

        IBufferItem IParentSet.Parent
        {
            set
            {
                parent = value;
                (parent as BufferDirectoryWrapper).items.Add(this);
            }
        }

        byte[] IBufferItem.Types
        {
            get
            {
                return item.Types;
            }

            set
            {
                item.Types = value;
            }
        }

        void IBufferItem.Delete()
        {
            List<IBufferItem> its = new List<IBufferItem>(items);
            foreach (IBufferItem it in its)
            {
                it.Delete();
            }
            item.Delete();
            if (parent != null)
            {
                (parent as BufferDirectoryWrapper).items.Remove(this);
            }
            StaticExtensionDataPerformerInterfaces.items.Remove(item.Id);
            StaticExtensionDataPerformerInterfaces.Data.SubmitChanges();
        }

        #endregion

    }
}