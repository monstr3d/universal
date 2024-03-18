using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    /// <summary>
    /// Log item
    /// </summary>
    public interface IBufferItem
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

        IBufferItem Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Type table recorded on bytes
        /// </summary>
        byte[] Types
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
