using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode 
    {
        /// <summary>
        /// Id
        /// </summary>
        object Id
        {
            get;
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
        /// Desctiption
        /// </summary>
        string Description
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
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void RemoveItself();
        
    }
}
