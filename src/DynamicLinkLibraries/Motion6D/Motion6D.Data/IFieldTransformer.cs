using System;
using System.Collections.Generic;
using System.Text;

using PhysicalField;

namespace Motion6D
{
    /// <summary>
    /// Transformer of field
    /// </summary>
    public interface IFieldTransformer
    {
        /// <summary>
        /// Transforms field
        /// </summary>
        /// <param name="transformMatrix">Transformation matrix</param>
        /// <param name="value">Value of field</param>
        /// <returns>Result of transformation</returns>
         object Transform(double[,] transformMatrix, object value);
    }
}
