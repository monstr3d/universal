using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Helpers
{
    /// <summary>
    /// Backup of object collection
    /// </summary> 
    public class ComponentCollectionBackup : IDisposable
    {
        #region Fields


        IComponentCollection collection;

        bool isDisposed = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        public ComponentCollectionBackup(IComponentCollection collection)
        {
            this.collection = collection;
            collection.Push();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            collection.Pop();
            isDisposed = true;
        }

        #endregion
    }
}
