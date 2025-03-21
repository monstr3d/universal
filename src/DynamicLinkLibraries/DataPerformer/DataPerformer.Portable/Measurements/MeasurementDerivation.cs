﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Measurement derivation
    /// </summary>
    public class MeasurementDerivation : Measurement, IDerivation
    {
        /// <summary>
        /// Derivation measure
        /// </summary>
        protected IMeasurement derivation;

        const Double a = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of measure</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="derivation">Derivation</param>
        /// <param name="name">Name</param>
        /// <param name="obj">Associated object</param>
        public MeasurementDerivation(object type, Func<object> parameter, 
            IMeasurement derivation, string name, object obj)
            : base(type, parameter, name, obj)
        {
            this.derivation = derivation;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <param name="derivation">Derivation</param>
        /// <param name="name">Name</param>
        /// <param name="obj">Associated object</param>
        public MeasurementDerivation(Func<object> parameter, IMeasurement derivation, string name, object obj)
            : this(a, parameter, derivation, name, obj)
        {

        }

        #region IDerivation Members

        IMeasurement IDerivation.Derivation
        {
            get { return derivation; }
        }

        #endregion

    }
}
