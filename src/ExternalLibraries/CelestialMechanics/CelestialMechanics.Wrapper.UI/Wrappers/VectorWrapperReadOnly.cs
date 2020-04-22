using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ResourceService.Attributes;


namespace CelestialMechanics.Wrapper.UI.Wrappers
{
    /// <summary>
    /// Wrapper of vector
    /// </summary>
    public class VectorWrapperReadOnly
    {
        #region Fields

        CelestialMechanics.Wrapper.Classes.Orbit orbit;

        double[] vector = new double[6];

        #endregion

        #region Ctor

        internal VectorWrapperReadOnly(CelestialMechanics.Wrapper.Classes.Orbit orbit)
        {
            this.orbit = orbit;
            orbit.GetMotionParameters(vector);
        }

        #endregion

        #region Public Properties


        /// <summary>
        /// X - coordinate
        /// </summary>
        [LocalizedCategory("Coordinates")]
        [LocalizedDescription("X")]
        public double X
        {
            get
            {
                return this[0];
            }
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        [LocalizedCategory("Coordinates")]
        [LocalizedDescription("Y")]
        public double Y
        {
            get
            {
                return this[1];
            }
         }

        /// <summary>
        /// Z - coordinate
        /// </summary>
        [LocalizedCategory("Coordinates")]
        [LocalizedDescription("Z")]
        public double Z
        {
            get
            {
                return this[2];
            }
         }

        /// <summary>
        /// Vx - velocity
        /// </summary>
        [LocalizedCategory("Velocity")]
        [LocalizedDescription("Vx")]
        public double Vx
        {
            get
            {
                return this[3];
            }
        }

        /// <summary>
        /// Vy - velocity
        /// </summary>
        [LocalizedCategory("Velocity")]
        [LocalizedDescription("Vy")]
        public double Vy
        {
            get
            {
                return this[4];
            }
        }

        /// <summary>
        /// Vz - velocity
        /// </summary>
        [LocalizedCategory("Velocity")]
        [LocalizedDescription("Vz")]
        public double Vz
        {
            get
            {
                return this[5];
            }
        }

        #endregion

        #region Private Members

        double this[int i]
        {
            get
            {
                orbit.GetMotionParameters(vector);
                return vector[i];
            }
            set
            {
                vector[i] = value;
                orbit.SetMotionParameters(vector,
                    orbit.Tuple.Item7);
            }
        }


        #endregion

    }
}
