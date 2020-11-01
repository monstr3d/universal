using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Chart.Drawing.Interfaces;


namespace Chart.Drawing.Points
{
    /// <summary>
    /// Base class of point
    /// </summary>
    [Serializable()]
    public class PointBase : IPoint, ISerializable
    {
        #region Fields

        /// <summary>
        /// The x coordinate
        /// </summary>
        double x;

        /// <summary>
        /// The y coordinate
        /// </summary>
        double y;

        object obj;

        #endregion

        #region Ctor

        public PointBase(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        protected PointBase(SerializationInfo info, StreamingContext context)
        {
            x = info.GetDouble("X");
            y = info.GetDouble("Y");
        }

        #endregion

        #region IPoint Members

        double IPoint.X
        {
            get { return x; }
        }

        double IPoint.Y
        {
            get { return y; }
        }

        object IPoint.Properties
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x);
            info.AddValue("Y", y);
        }

        #endregion
    }
}
