using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Iterator
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// Resets itself
        /// </summary>
        void Reset();

        /// <summary>
        /// Go to next and false otherwise
        /// </summary>
        /// <returns>True if has next and</returns>
        bool Next();

    }
}
