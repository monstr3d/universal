using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Transformer of field
    /// </summary>
    internal class FieldTransformer
    {
        private static readonly FieldTransformer obj = new FieldTransformer();

        /// <summary>
        /// Transformer of field
        /// </summary>
        protected FieldTransformer()
        {

        }

        /// <summary>
        /// Transforms field
        /// </summary>
        /// <param name="o">Input</param>
        /// <returns>Output</returns>
        internal virtual object Transform(object o)
        {
            return o;
        }

        /// <summary>
        /// Sets a frame
        /// </summary>
        /// <param name="relative">Relative frame</param>
        internal virtual void Set(ReferenceFrame relative)
        {

        }

        /// <summary>
        /// Creates transformer
        /// </summary>
        /// <param name="type">Return type</param>
        /// <param name="covariance">Covariance</param>
        /// <returns>Created transformer</returns>
        internal static FieldTransformer Create(object type, object covariance)
        {
            if (type is ArrayReturnType)
            {
                ArrayReturnType at = type as ArrayReturnType;
                if (!at.IsObjectType)
                {
                    if (at.Dimension.Length == 1)
                    {
                        if (at.Dimension[0] == 3)
                        {
                            if (covariance.Equals(Field3D_Types.CovariantVector))
                            {
                                return new CovariantVectorFieldTransformer();
                            }
                        }
                    }
                }
            }
            return obj;
        }
    }
}
