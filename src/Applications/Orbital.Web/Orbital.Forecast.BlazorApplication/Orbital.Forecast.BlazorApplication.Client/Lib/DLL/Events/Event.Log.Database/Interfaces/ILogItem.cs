using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Log.Database.Interfaces
{
    /// <summary>
    /// Log item
    /// </summary>
    public interface ILogItem
    {
        /// <summary>
        /// Id
        /// </summary>
        object Id
        {
            get;
        }

        /// <summary>
        /// Id of parent
        /// </summary>
        object ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Comment
        /// </summary>
        string Comment
        {
            get;
            set;
        }

        /// <summary>
        /// Date time
        /// </summary>
        DateTime DateTime
        {
            get;
        }
        
        ILogItem Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Deletes itself
        /// </summary>
        void Delete();    
    }
}
