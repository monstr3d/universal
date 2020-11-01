using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes.Extended
{
    /// <summary>
    /// Return type of array
    /// </summary>
    [Serializable]
    public class ArrayReturnType : BaseTypes.ArrayReturnType, ISerializable
    {
        #region Ctor

        private ArrayReturnType(BaseTypes.ArrayReturnType type)
        {
            elementType = type.ElementType;
            dimension = type.Dimension;
            isObjectType = type.IsObjectType;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ArrayReturnType(SerializationInfo info, StreamingContext context)
        {
            elementType = info.GetValue("ElementType", typeof(object));
            dimension = info.GetValue("Dimension", typeof(int[])) as int[];
            isObjectType = info.GetBoolean("IsObjectType");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ElementType", elementType, typeof(object));
            info.AddValue("Dimension", dimension, typeof(int[]));
            info.AddValue("IsObjectType", isObjectType);
        }

        #endregion

        #region Converter

        /// <summary>
        /// Converter
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Conversion result</returns>
        public static object Convert(object o)
        {
            if (o.GetType().Equals(typeof(BaseTypes.ArrayReturnType)))
            {
                return new ArrayReturnType(o as BaseTypes.ArrayReturnType);
            }
            return o;
        }

        #endregion
    }

}

