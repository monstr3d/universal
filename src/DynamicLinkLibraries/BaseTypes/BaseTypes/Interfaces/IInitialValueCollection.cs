using System.Collections.Generic;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Collection of initial values
    /// </summary>
    public interface IInitialValueCollection
    {
        /// <summary>
        /// Values
        /// </summary>
        IEnumerable<IInitialValue> Values { get; }

        /// <summary>
        /// Adds a value
        /// </summary>
        /// <param name="value"></param>
        void Add(IInitialValue value);

        /// <summary>
        /// Sets all
        /// </summary>
        void Set();

        /// <summary>
        /// Clears itself
        /// </summary>
        void Clear();
    }
}
