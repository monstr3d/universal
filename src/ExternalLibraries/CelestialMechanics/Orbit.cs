using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialMechanics
{
    /// <summary>
    /// Celestial orbit
    /// </summary>
    public abstract class Orbit
    {

        /// <summary>
        ///  Return the position in the orbit's reference frame at the specified
        ///  time (TDB). Units are kilometers.
        /// </summary>
        /// <param name="jd">Time</param>
        /// <param name="position">Position</param>
        public abstract void positionAtTime(double jd, double[] position);

        /// <summary>
        /// Return the orbital velocity in the orbit's reference frame at the
        ///  specified time (TDB). Units are kilometers per day. If the method
        ///  is not overridden, the velocity will be computed by differentiation
        ///  of position.
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="velocity">Orbital velocity in the orbit's reference</param>
         public abstract void velocityAtTime(double time, double[] velocity);

         /// <summary>
         /// Return the orbital velocity in the orbit's reference frame at the
         ///  specified time (TDB). Units are kilometers per day. If the method
         ///  is not overridden, the velocity will be computed by differentiation
         ///  of position.
         /// </summary>
         /// <param name="time">Time</param>
         /// <param name="vector">Orbital state in the orbit's reference</param>
         public abstract void vectorAtTime(double time, double[] vector);


        /// <summary>
        /// Period
        /// </summary>
        public abstract double Period
        {
            get;
        }

        /// <summary>
        /// Bounding radius
        /// </summary>
        public abstract double BoundingRadius
        {
            get;
        }

        /// <summary>
        /// Sample
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="t">Time</param>
        /// <param name="nSamples">Number of samples</param>
        /// <param name="sample">Sample function</param>
        public abstract void sample(double start, double t,
                             int nSamples, Action<double, double[]> sample);

        /// <summary>
        /// "Is periodic" sign
        /// </summary>
        public virtual bool IsPeriodic
        {
            get { return true; }
        }

         /// <summary>
        /// Return the time range over which the orbit is valid; if the orbit
        /// is always valid, begin and end should be equal.
        /// </summary>
        /// <param name="begin">Begin of interval</param>
        /// <param name="end">End of interval</param>
        public virtual void getValidRange(out double begin, out double end)
        { 
            begin = 0.0; 
            end = 0.0; 
        }

    }
}
