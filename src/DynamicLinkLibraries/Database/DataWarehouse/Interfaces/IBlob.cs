using System;
using System.Collections.Generic;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Blob consumer
    /// </summary>
    public interface IBlob
    {
        /// <summary>
        /// Bytes
        /// </summary>
        byte[] Bytes
        {
            get;
            set;
        }

        /// <summary>
        /// Extension
        /// </summary>
        string Extension
        {
            get;
            set;
        }
    }
}
