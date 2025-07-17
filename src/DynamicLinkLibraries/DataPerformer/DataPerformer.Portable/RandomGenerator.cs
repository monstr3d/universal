using System;
using System.Collections.Generic;

using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using NamedTree;

namespace DataPerformer.Portable
{
    public class RandomGenerator : CategoryObject, IMeasurements
    {
        #region Fields

        Random random = new Random();


        private bool isUpdated;

        private IMeasurement measurement;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RandomGenerator()
        {
            Init();
        }



        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion



        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 1; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measurement; }
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

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [measurement];

        #endregion

        #region Specifc Members

        private void Init()
        {
            Double a = 0;
            Func<object> p = getMeasure;
            measurement = new Measurement(a, p, "Random", this);
        }

        private object getMeasure()
        {
            return random.NextDouble();
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion
    }
}