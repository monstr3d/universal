using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalField.Interfaces
{
    /// <summary>
    /// Factory of fields
    /// </summary>
    public interface IFieldFactory
    {

        /// <summary>
        /// Gets field consumer from prototype
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The field consumer</returns>
        IFieldConsumer GetConsumer(object obj);


        /// <summary>
        /// Gets a field from prototype
        /// </summary>
        /// <param name="consumer">Field consumer</param>
        /// <param name="obj">Prototype</param>
        /// <returns>The field</returns>
        IPhysicalField GetField(IFieldConsumer consumer, object obj);

    }
}
