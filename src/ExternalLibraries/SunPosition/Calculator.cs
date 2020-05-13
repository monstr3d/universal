using System;


namespace SunPosition
{

    /// <summary>
    /// Location
    /// </summary>
    public struct cLocation
    {
        public double dLongitude;
        public double dLatitude;
    };

    /// <summary>
    /// Coordinates of Sun
    /// </summary>
    public struct cSunCoordinates
    {
        public double dZenithAngle;
        public double dAzimuth;
    };

    /// <summary>
    /// Calculator of Sun position
    /// This is a С# version of http://www.psa.es/sdg/sunpos.htm
    /// </summary>
    public class Calculator
    {
        #region Fields

        const double dEarthMeanRadius = 6371.01;	// In km
        const double dAstronomicalUnit = 149597890;	// In km


        #endregion

        /// <summary>
        /// Date time to Julian day
        /// </summary>
        /// <param name="Date">Date</param>
        /// <returns>Julian day</returns>
        public long ConvertToJulian(DateTime Date)
        {
            int Month = Date.Month;
            int Day = Date.Day;
            int Year = Date.Year;

            if (Month < 3)
            {
                Month = Month + 12;
                Year = Year - 1;
            }
            long JulianDay = Day + (153 * Month - 457) / 5 + 365 * Year + (Year / 4) - (Year / 100) + (Year / 400) + 1721119;
            return JulianDay;
        }


        /// <summary>
        /// Gets position of Sun
        /// </summary>
        /// <param name="time"></param>
        /// <param name="dDeclination"></param>
        /// <param name="dRightAscension"></param>
        public void GetPosition(DateTime time,
           out double dDeclination, out double dRightAscension, 
            out double dElapsedJulianDays,
            out double dDecimalHours)
        {
            dDecimalHours = (double)time.Hour + ((double)time.Minute
                  + (double)time.Second / 60.0) / 60.0;


           dElapsedJulianDays = ConvertToJulian(time) - 0.5 - 2451545.0 + dDecimalHours / 24.0;

            // Calculate ecliptic coordinates (ecliptic longitude and obliquity of the 
            // ecliptic in radians but without limiting the angle to be less than 2*Pi 
            // (i.e., the result may be greater than 2*Pi)
            double dMeanLongitude;
            double dMeanAnomaly;
            double dOmega;
            dOmega = 2.1429 - 0.0010394594 * dElapsedJulianDays;
            dMeanLongitude = 4.8950630 + 0.017202791698 * dElapsedJulianDays; // Radians
            dMeanAnomaly = 6.2400600 + 0.0172019699 * dElapsedJulianDays;
            double dEclipticLongitude = dMeanLongitude + 0.03341607 * Math.Sin(dMeanAnomaly)
                + 0.00034894 * Math.Sin(2 * dMeanAnomaly) - 0.0001134
                - 0.0000203 * Math.Sin(dOmega);
            double dEclipticObliquity = 0.4090928 - 6.2140e-9 * dElapsedJulianDays
                + 0.0000396 * Math.Cos(dOmega);

            // Calculate celestial coordinates ( right ascension and declination ) in radians 
            // but without limiting the angle to be less than 2*Pi (i.e., the result may be 
            // greater than 2*Pi)

            double dSin_EclipticLongitude;
            dSin_EclipticLongitude = Math.Sin(dEclipticLongitude);
            double dY = Math.Cos(dEclipticObliquity) * dSin_EclipticLongitude;
            double dX = Math.Cos(dEclipticLongitude);
            dRightAscension = Math.Atan2(dY, dX);
            if (dRightAscension < 0.0)
            {
                dRightAscension = dRightAscension + 2 * Math.PI;
            }
            dDeclination = Math.Asin(Math.Sin(dEclipticObliquity) * dSin_EclipticLongitude);

      }


        /// <summary>
        /// Gets position of Sun
        /// </summary>
        /// <param name="udtTime">Time</param>
        /// <param name="udtLocation">Location</param>
        /// <param name="udtSunCoordinates">Sun coorditates</param>
        /// <param name="dDeclination">Declination</param>
        /// <param name="dRightAscension">Right Ascension </param>
        public void GetPosition(DateTime udtTime, cLocation udtLocation, ref cSunCoordinates udtSunCoordinates,
            out double dDeclination, out double dRightAscension, out double dElapsedJulianDays, out double dDecimalHours)
        {
            // Auxiliary variables
            double dY;
            double dX;

            GetPosition(udtTime, out dDeclination, out dRightAscension, 
                out dElapsedJulianDays, out dDecimalHours);
 
            double dGreenwichMeanSiderealTime;
            double dLocalMeanSiderealTime;
            double dLatitudeInRadians;
            double dHourAngle;
            double dCos_Latitude;
            double dSin_Latitude;
            double dCos_HourAngle;
            double dParallax;
     
            dGreenwichMeanSiderealTime = 6.6974243242 +
                0.0657098283 * dElapsedJulianDays
                + dDecimalHours;
            dLocalMeanSiderealTime = ((dGreenwichMeanSiderealTime * 15 * Math.PI) / 180.0
                + udtLocation.dLongitude);
            dHourAngle = dLocalMeanSiderealTime - dRightAscension;
            dLatitudeInRadians = udtLocation.dLatitude;
            dCos_Latitude = Math.Cos(dLatitudeInRadians);
            dSin_Latitude = Math.Sin(dLatitudeInRadians);
            dCos_HourAngle = Math.Cos(dHourAngle);
            udtSunCoordinates.dZenithAngle = (Math.Acos(dCos_Latitude * dCos_HourAngle
                * Math.Cos(dDeclination) + Math.Sin(dDeclination) * dSin_Latitude));
            dY = -Math.Sin(dHourAngle);
            dX = Math.Tan(dDeclination) * dCos_Latitude - dSin_Latitude * dCos_HourAngle;
            udtSunCoordinates.dAzimuth = Math.Atan2(dY, dX);
            if (udtSunCoordinates.dAzimuth < 0.0)
            {
                udtSunCoordinates.dAzimuth = udtSunCoordinates.dAzimuth + 2 * Math.PI;
            }
            // Parallax Correction
            dParallax = (dEarthMeanRadius / dAstronomicalUnit)
                * Math.Sin(udtSunCoordinates.dZenithAngle);
            udtSunCoordinates.dZenithAngle = (udtSunCoordinates.dZenithAngle
                + dParallax);
        }
    }
}