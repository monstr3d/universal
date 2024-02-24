using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces.BufferedData.Interfaces;

namespace DataPerformer.Interfaces.BufferedData
{
    public class BufferItemWrapper : IBufferData, IParentSet
    {
        #region Fields

        protected IBufferData item;

        internal List<IBufferItem> items = new List<IBufferItem>();

        protected IBufferItem parent;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        public BufferItemWrapper(IBufferData item)
        {
            this.item = item;
            StaticExtensionDataPerformerInterfaces.items[item.Id] = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="parent">Parent</param>
        public BufferItemWrapper(BufferDirectoryWrapper parent, IBufferData item)
        {
            this.item = item;
            this.parent = parent;
            parent.items.Add(this);
            StaticExtensionDataPerformerInterfaces.items[item.Id] = this;
        }

        /// <summary>
        /// Default constructor for subcalasses
        /// </summary>
        protected BufferItemWrapper()
        {

        }

        #endregion

        #region Interface Implementation

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
                    throw new Exception(value + " already exists");
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

        int IBufferData.Length
        {
            get
            {
                return item.Length;
            }
        }

        IEnumerable<byte[]> IBufferData.Buffer
        {
            get
            {
                return item.Buffer;
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
            item.Delete();
            StaticExtensionDataPerformerInterfaces.items.Remove(item.Id);
            (parent as BufferDirectoryWrapper).items.Remove(this);
        }

        #endregion

        IBufferItem IParentSet.Parent
        {
            set
            {
                parent = value;
                (parent as BufferDirectoryWrapper).items.Add(this);
            }
        }

    }
}