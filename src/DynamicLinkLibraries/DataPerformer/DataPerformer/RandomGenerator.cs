using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

namespace DataPerformer
{
    /// <summary>
    /// Generator of random numbers
    /// </summary>
    [Serializable()]
    public class RandomGenerator : CategoryObject, ISerializable, IMeasurements
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
            init();
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RandomGenerator(SerializationInfo info, StreamingContext context)
        {
            init();
        }

        #endregion


        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 1; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measure; }
        }

        void IMeasurements.UpdateMeasurements()
        {
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region Specifc Members

        private void init()
        {
            Double a = 0;
            Func<object> p = getMeasure;
            measure = new Measurement(a, p, "Random");
        }

        private object getMeasure()
        {
            return random.NextDouble();
        }

        #endregion
    }
}
