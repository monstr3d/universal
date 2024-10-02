using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    /// <summary>
    /// Datadase interface
    /// </summary>
    public interface IDatabaseInterface
    {

        /// <summary>
        /// Connection string
        /// </summary>
        string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Elements
        /// </summary>
        IEnumerable<object> Elements
        {
            get;
        }

        /// <summary>
        /// Creates data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="parentId">Parent id</param>
        /// <param name="name">Name</param>
        /// <param name="fileName">File name</param>
        /// <param name="comment">Comment</param>
        /// <returns>Log data</returns>
        IBufferData Create(IEnumerable<byte[]> data, object parentId, 
            string name, string fileName, string comment);
     
        /// <summary>
        /// Access to an item
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The item</returns>
        IBufferItem this[object id]
        {
            get;
        }

        /// <summary>
        /// Creates new a item
        /// </summary>
        /// <param name="parentId">Parent Id</param>
        /// <param name="name">Name</param>
        /// <param name="comment">Comment</param>
        /// <returns>The new item</returns>
        IBufferItem Create(object parentId, string name, string comment);
 
        /// <summary>
        /// Submits all changes
        /// </summary>
        void SubmitChanges();

    }
}
