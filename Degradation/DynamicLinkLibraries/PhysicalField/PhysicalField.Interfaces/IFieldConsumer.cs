using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalField.Interfaces
{
    /// <summary>
    /// Irradiated object
    /// </summary>
    public interface IFieldConsumer
    {
        /// <summary>
        /// Dimension of space
        /// </summary>
        int SpaceDimension
        {
            get;
        }

        /// <summary>
        /// Count of external field
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Access to the n - th field
        /// </summary>
        /// <param name="n">Field number</param>
        /// <returns>The n - th field</returns>
        IPhysicalField this[int n]
        {
            get;
        }

        /// <summary>
        /// Adds field
        /// </summary>
        /// <param name="field">Field to add</param>
        void Add(IPhysicalField field);

        /// <summary>
        /// Removes field
        /// </summary>
        /// <param name="field">Field to remove</param>
        void Remove(IPhysicalField field);

        /// <summary>
        /// Consumes field
        /// </summary>
        void Consume();


    }
}
