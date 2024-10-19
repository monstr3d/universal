using System;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Adding and removing objects
    /// </summary>
    public interface IAddRemove
    {
        /// <summary>
        /// Adds object
        /// </summary>
        /// <param name="obj">The object to add</param>
        void Add(object obj);

        /// <summary>
        /// Removes object
        /// </summary>
        /// <param name="obj">The object to remove</param>
        void Remove(object obj);

        /// <summary>
        /// Type of element
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// Add
        /// </summary>
        event Action<object> AddAction;

        /// <summary>
        /// Remove
        /// </summary>
        event Action<object> RemoveAction;

    }
}
