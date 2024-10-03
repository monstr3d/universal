using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Regression
{

    /// <summary>
    /// General linear method with iterator
    /// </summary>
    [Serializable()]
    public class IteratorGLM :  Portable.IteratorGLM, ISerializable
    {
        #region Constuctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorGLM() : 
            base()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected IteratorGLM(SerializationInfo info, StreamingContext context)
            : this()
        {
            sAliases = info.GetValue("Aliases", typeof(List<string>)) as List<string>;
            sLeft = info.GetValue("Left", typeof(List<string>)) as List<string>;
            sRight = info.GetValue("Right", typeof(List<string>)) as List<string>;
            sR = info.GetValue("R", typeof(List<List<string>>)) as List<List<string>>;
            dx = info.GetValue("Dx", typeof(double[])) as double[];
            d = info.GetValue("D", typeof(double[,])) as double[,];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Aliases", sAliases, typeof(List<string>));
            info.AddValue("Left", sLeft, typeof(List<string>));
            info.AddValue("Right", sRight, typeof(List<string>));
            info.AddValue("R", sR, typeof(List<List<string>>));
            info.AddValue("Dx", dx, typeof(double[]));
            info.AddValue("D", d, typeof(double[,]));
        }

        #endregion
    }
}
