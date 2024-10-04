using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicalField.Interfaces
{
    /// <summary>
    /// Physical Field
    /// </summary>
    public interface IPhysicalField
    {
        /// <summary>
        /// Dimension of space
        /// </summary>
        int SpaceDimension
        {
            get;
        }

        /// <summary>
        /// Count of components
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Type of n - th component
        /// </summary>
        /// <param name="n">Component number</param>
        /// <returns>Type of n-th component</returns>
        object GetType(int n);


        /// <summary>
        /// Type of transformation of n - th component
        /// </summary>
        /// <param name="n">Component number</param>
        /// <returns>Transformation type</returns>
        object GetTransformationType(int n);

        /// <summary>
        /// Calculates field
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Array of components of field</returns>
        object[] this[double[] position]
        {
            get;
        }
    }
}
