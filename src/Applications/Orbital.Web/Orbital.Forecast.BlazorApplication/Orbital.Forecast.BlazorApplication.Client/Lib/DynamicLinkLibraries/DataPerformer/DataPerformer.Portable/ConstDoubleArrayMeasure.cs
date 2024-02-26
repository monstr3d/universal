using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Constant measure of double array
    /// </summary>
    public class ConstDoubleArrayMeasure : IMeasurement
    {
        #region Fields

        /// <summary>
        /// Array
        /// </summary>
        protected double[] array;

        private string name;

        private ArrayReturnType type;

        private Func<object> par;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">Measure dtata</param>
        /// <param name="name">Measure name</param>
        public ConstDoubleArrayMeasure(double[] array, string name)
        {
            this.array = array;
            this.name = name;
            type = new ArrayReturnType(FixedTypes.Double, new int[] { array.Length }, false);
            par = getPar;
        }

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return par; }
        }

        string IMeasurement.Name
        {
            get { return name; }
        }

        object IMeasurement.Type
        {
            get { return type; }
        }

        #endregion

        #region Specific Members

        object getPar()
        {
            return array;
        }

        #endregion


    }
}
