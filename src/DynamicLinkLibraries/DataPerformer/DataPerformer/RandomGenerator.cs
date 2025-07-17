using System;
using System.Runtime.Serialization;


using DataPerformer.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// Generator of random numbers
    /// </summary>
    [Serializable()]
    public class RandomGenerator : Portable.RandomGenerator, ISerializable
    {
        #region Fields

        Random random = new Random();


        private bool isUpdated;

        private IMeasurement measure;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RandomGenerator()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RandomGenerator(SerializationInfo info, StreamingContext context)
        {
        }

    
        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

   
    }
}
