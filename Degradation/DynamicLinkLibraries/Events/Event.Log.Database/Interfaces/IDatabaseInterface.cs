using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Log.Database.Interfaces
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
        ILogData Create(IEnumerable<byte[]> data, object parentId, string name, string fileName, string comment);

        /// <summary>
        /// Creates interval
        /// </summary>
        /// <param name="parentId">Parent id</param>
        /// <param name="name">Name</param>
        /// <param name="comment">Comment</param>
        /// <param name="data">Data</param>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>Inte</returns>
        ILogInterval CreateInterval(object parentId, string name,  string comment, 
            ILogData data, uint begin, uint end);

        /// <summary>
        /// Access to an item
        /// </summary>
        /// <param name="id">The item id</param>
        /// <returns>The item</returns>
        ILogItem this[object id]
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
        ILogItem Create(object parentId, string name, string comment);

        /// <summary>
        /// Names of files
        /// </summary>
        List<string> Filenames
        {
            get;
        }

        /// <summary>
        /// Types of records
        /// </summary>
        Dictionary<int, string[]> Types
        {
            get;
        }

        /// <summary>
        /// Submits all changes
        /// </summary>
        void SubmitChanges();
    }
}
