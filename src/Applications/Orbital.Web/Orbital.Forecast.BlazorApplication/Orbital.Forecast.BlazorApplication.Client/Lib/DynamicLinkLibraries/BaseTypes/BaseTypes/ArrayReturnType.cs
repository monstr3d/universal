using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes
{
    /// <summary>
    /// Return type of array
    /// </summary>
    public class ArrayReturnType
    {

        #region Fields

        protected  object elementType;

        protected  int[] dimension;

        protected  bool isObjectType;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elementType">Type of element</param>
        /// <param name="dimension">Dimension</param>
        /// <param name="objectType">The "is object" sign</param>
        public ArrayReturnType(object elementType, int[] dimension, bool objectType)
        {
            this.elementType = elementType;
            this.dimension = dimension;
            isObjectType = objectType;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ArrayReturnType()
        {

        }

        #endregion

        /// <summary>
        /// The "is object" sign
        /// </summary>
        public bool IsObjectType
        {
            get
            {
                return isObjectType;
            }
        }

        /// <summary>
        /// Dimension
        /// </summary>
        public int[] Dimension
        {
            get
            {
                return dimension;
            }
        }

        /// <summary>
        /// Type of element
        /// </summary>
        public object ElementType
        {
            get
            {
                return elementType;
            }
        }

        /// <summary>
        /// Overriden Equals
        /// </summary>
        /// <param name="obj">Compared obje</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ArrayReturnType))
            {
                return false;
            }
            ArrayReturnType at = obj as ArrayReturnType;
            if (!at.elementType.Equals(elementType))
            {
                return false;
            }
            if (at.dimension.Length != dimension.Length)
            {
                return false;
            }
            for (int i = 0; i < dimension.Length; i++)
            {
                if (dimension[i] != at.dimension[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Overriden
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return dimension.Length * dimension[0];
        }

        /// <summary>
        /// Checks equality of imension
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>True in case of equal dimesion and false otherwise</returns>
        public bool HasEqualDimension(ArrayReturnType type)
        {
            if (type.dimension.Length != dimension.Length)
            {
                return false;
            }
            for (int i = 0; i < dimension.Length; i++)
            {
                if (dimension[i] != type.dimension[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets base type
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Object's base type</returns>
        static public object GetBaseType(object o)
        {
            if (o is ArrayReturnType)
            {
                ArrayReturnType rt = o as ArrayReturnType;
                return rt.elementType;
            }
            return o;
        }
    }
}
