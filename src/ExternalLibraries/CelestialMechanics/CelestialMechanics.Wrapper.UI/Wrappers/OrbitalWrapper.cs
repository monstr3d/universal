using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;

using ResourceService.Attributes;

using CelestialMechanics.Wrapper.Classes;

namespace CelestialMechanics.Wrapper.UI.Wrappers
{
    /// <summary>
    /// Wrapper of coordinates
    /// </summary>
    public class OrbitalWrapper
    {
        #region Fields

        CelestialMechanics.Wrapper.Classes.Orbit orbit;

        #endregion

        #region Ctor

        internal OrbitalWrapper(CelestialMechanics.Wrapper.Classes.Orbit orbit)
        {
            this.orbit = orbit;
        }



        #endregion

        #region Public Properties

        /// <summary>
        /// Pericenter Distance
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Pericenter Distance")]
        [LocalizedDescription("Pericenter Distance")]
        public double PericenterDistance
        {
            get
            {
                return this[0];
            }
            set
            {
                this[0] = value;
            }
        }

        /// <summary>
        /// Eccentricity
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Eccentricity")]
        [LocalizedDescription("Eccentricity")]
        public double Eccentricity
        {
            get
            {
                return this[1];
            }
            set
            {
                this[1] = value;
            }
        }

        /// <summary>
        /// Pericenter Distance
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Inclination")]
        [LocalizedDescription("Inclination")]
        public double Inclination
        {
            get
            {
                return this[2];
            }
            set
            {
                this[2] = value;
            }
        }

        /// <summary>
        /// Pericenter Distance
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Ascending Node")]
        [LocalizedDescription("Ascending Node")]
        public double AscendingNode
        {
            get
            {
                return this[3];
            }
            set
            {
                this[3] = value;
            }
        }

        /// <summary>
        /// Argument of Periapsis
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Argument of Periapsis")]
        [LocalizedDescription("Argument of Periapsis")]
        public double ArgumentOfPeriapsis
        {
            get
            {
                return this[4];
            }
            set
            {
                this[4] = value;
            }
        }

        /// <summary>
        /// Mean Anomaly at Epoch
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Mean Anomaly at Epoch")]
        [LocalizedDescription("Mean Anomaly at Epoch")]
        public double MeanAnomalyAtEpoch
        {
            get
            {
                return this[5];
            }
            set
            {
                this[5] = value;
            }
        }

        /// <summary>
        /// Mean Anomaly at Epoch
        /// </summary>
        [LocalizedCategory("Osculating Elements")]
        [LocalizedDisplayName("Period")]
        [LocalizedDescription("Period")]
        public double Period
        {
            get
            {
                return orbit.Period;
            }
         }

        /// <summary>
        /// Epoch
        /// </summary>
        [LocalizedCategory("Parameters")]
        [LocalizedDisplayName("Epoch")]
        [LocalizedDescription("Epoch")]
        public DateTime Epoch
        {
            get
            {
                return orbit.Tuple.Item7;
            }
            set
            {
                Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> t = orbit.Tuple;
                orbit.Tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>(
                    t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, value, t.Rest);
            }
        }

        /// <summary>
        /// Mass
        /// </summary>
        [LocalizedCategory("Parameters")]
        [LocalizedDisplayName("Mass")]
        [LocalizedDescription("Mass")]
        public double Mass
        {
            get
            {
                return orbit.Tuple.Item4;
            }
            set
            {
                Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> t = orbit.Tuple;
                orbit.Tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>(
                    t.Item1, t.Item2, t.Item3, value, t.Item5, t.Item6, t.Item7, t.Rest);
            }
        }

        /// <summary>
        /// FD Mean Motion
        /// </summary>
        [LocalizedCategory("Parameters")]
        [LocalizedDisplayName("FD Mean Motion")]
        [LocalizedDescription("FD Mean Motion")]
        public double FD
        {
            get
            {
                return orbit.Tuple.Rest.Item2[0];
            }
            set
            {
                Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> t = orbit.Tuple;
                t.Rest.Item2[0] = value;
                orbit.Tuple = t;
            }
        }

        /// <summary>
        /// SD Mean Motion
        /// </summary>
        [LocalizedCategory("Parameters")]
        [LocalizedDisplayName("SD Mean Motion")]
        [LocalizedDescription("SD Mean Motion")]
        public double SD
        {
            get
            {
                return orbit.Tuple.Rest.Item2[1];
            }
            set
            {
                Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                    double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> t = orbit.Tuple;
                t.Rest.Item2[1] = value;
                orbit.Tuple = t;
            }
        }


 
 
 
        #endregion


        #region Private Members

        double this[int i]
        {
            get
            {
                return orbit.Tuple.Item5[i];
            }
            set
            {
                orbit.Tuple.Item5[i] = value;
                orbit.CreateOrbit();
            }
        }

        #endregion
    }
}
