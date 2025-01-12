using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chart.Drawing.Interfaces.Points
{
    [Serializable()]
    public class MultiPoint : IPoint, ISerializable
    {
        #region Fields

        object properties;

        double x;
        
        double[] y;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinates</param>
        public MultiPoint(double x, double[] y)
        {
            this.x = x;
            this.y = y;
        }


        private MultiPoint(SerializationInfo info, StreamingContext context)
        {
            x = info.GetDouble("X");
            y = info.GetValue("Y", typeof(double[])) as double[];
        }

        #endregion


        double IPoint.X => x;

        double[] IPoint.Y => y;

        object IPoint.Properties { get => properties; set => properties = value; }

        int IPoint.YCount => y.Length;
       

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x); 
            info.AddValue("Y", y, typeof(double[]));
        }
    }
}
