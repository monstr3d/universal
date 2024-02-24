using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Linear forecast
    /// </summary>
    public interface ILinear6DForecast
    {

        /// <summary>
        /// Frame
        /// </summary>
        ReferenceFrame ReferenceFrame
        {
            get;
        }


        /// <summary>
        /// Forecast time
        /// </summary>
        TimeSpan ForecastTime
        {
            get;
            set;
        }

        /// <summary>
        /// Error of coordinate
        /// </summary>
        double CoordinateError
        {
            get;
            set;
        }

        /// <summary>
        /// Error of angle
        /// </summary>
        double AngleError
        {
            get;
            set;
        }
    }
}
