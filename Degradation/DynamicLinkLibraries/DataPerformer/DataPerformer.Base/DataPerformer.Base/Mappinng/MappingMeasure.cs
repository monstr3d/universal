using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataPerformer.Interfaces;

namespace DataPerformer.Mappinng
{
    /// <summary>
    /// Mapping measure
    /// </summary>
    public class MappingMeasure : IMeasurement
    {
        #region Fields

        IMeasurement measure;

        string name;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Mapping name</param>
        /// <param name="measure">Measure</param>
        public MappingMeasure(string name, IMeasurement measure)
        {
            this.name = name;
            this.measure = measure;

        }

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return measure.Parameter; }
        }

        string IMeasurement.Name
        {
            get { return name; }
        }

        object IMeasurement.Type
        {
            get { return measure.Type; }
        }

        #endregion
    }
}
