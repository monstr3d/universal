package external.sun.service;

import external.geography.GeoCoordinates;

import java.time.LocalDateTime;

public class SunPosition {
    /// <summary>
    /// Date time to Julian day
    /// </summary>
    /// <param name="Date">Date</param>
    /// <returns>Julian day</returns>
    public  static long convertToJulian(LocalDateTime Date)
    {
        int Month = Date.getMonthValue();
        int Day = Date.getDayOfMonth();
        int Year = Date.getYear();

        if (Month < 3)
        {
            Month = Month + 12;
            Year = Year - 1;
        }
        long JulianDay = Day + (153L * Month - 457) / 5 + 365L * Year + (Year / 4) - (Year / 100) + (Year / 400) + 1721119;
        return JulianDay;
    }


    /// <summary>
    /// Gets position of Sun
    /// </summary>
    /// <param name="time"></param>
    /// <param name="dDeclination"></param>
    /// <param name="dRightAscension"></param>
    public static void getPosition(LocalDateTime time,
                            double[] dDeclination, double[] dRightAscension,
                            double[] dElapsedJulianDays,
                            double[] dDecimalHours)
    {
        var h = time.getHour();
        var m = time.getMinute();
        var s = time.getSecond();

        var ss = (double)s / 60.0;

        var mm = ((double)m + ss) / 60;

        dDecimalHours[0] = (double) h + mm;


        dElapsedJulianDays[0] = convertToJulian(time) - 0.5 - 2451545.0 + dDecimalHours[0] / 24.0;

        // Calculate ecliptic coordinates (ecliptic longitude and obliquity of the
        // ecliptic in radians but without limiting the angle to be less than 2*Pi
        // (i.e., the result may be greater than 2*Pi)
        double dMeanLongitude;
        double dMeanAnomaly;
        double dOmega;
        dOmega = 2.1429 - 0.0010394594 * dElapsedJulianDays[0];
        dMeanLongitude = 4.8950630 + 0.017202791698 * dElapsedJulianDays[0]; // Radians
        dMeanAnomaly = 6.2400600 + 0.0172019699 * dElapsedJulianDays[0];
        double dEclipticLongitude = dMeanLongitude + 0.03341607 * Math.sin(dMeanAnomaly)
                + 0.00034894 * Math.sin(2 * dMeanAnomaly) - 0.0001134
                - 0.0000203 * Math.sin(dOmega);
        double dEclipticObliquity = 0.4090928 - 6.2140e-9 * dElapsedJulianDays[0]
                + 0.0000396 * Math.cos(dOmega);

        // Calculate celestial coordinates ( right ascension and declination ) in radians
        // but without limiting the angle to be less than 2*Pi (i.e., the result may be
        // greater than 2*Pi)

        double dSin_EclipticLongitude;
        dSin_EclipticLongitude = Math.sin(dEclipticLongitude);
        double dY = Math.cos(dEclipticObliquity) * dSin_EclipticLongitude;
        double dX = Math.cos(dEclipticLongitude);
        dRightAscension[0] = Math.atan2(dY, dX);
        if (dRightAscension[0] < 0.0) {
            dRightAscension[0] = dRightAscension[0] + 2 * Math.PI;
        }
        dDeclination[0] = Math.asin(Math.sin(dEclipticObliquity) * dSin_EclipticLongitude);
    }


    /// <summary>
    /// Gets position of Sun
    /// </summary>
    /// <param name="udtTime">Time</param>
    /// <param name="udtLocation">Location</param>
    /// <param name="udtSunCoordinates">Sun coorditates</param>
    /// <param name="dDeclination">Declination</param>
    /// <param name="dRightAscension">Right Ascension </param>
    public static void getPosition(LocalDateTime udtTime, GeoCoordinates udtLocation, SunCoordinates udtSunCoordinates,
                                   double[] dDeclination, double[] dRightAscension, double[] dElapsedJulianDays, double[] dDecimalHours)
    {
        // Auxiliary variables
        double dY;
        double dX;

        getPosition(udtTime, dDeclination, dRightAscension,
                dElapsedJulianDays, dDecimalHours);

        double dGreenwichMeanSiderealTime;
        double dLocalMeanSiderealTime;
        double dLatitudeInRadians;
        double dHourAngle;
        double dCos_Latitude;
        double dSin_Latitude;
        double dCos_HourAngle;
        double dParallax;

        dGreenwichMeanSiderealTime = 6.6974243242 +
                0.0657098283 * dElapsedJulianDays[0]
                + dDecimalHours[0];
        dLocalMeanSiderealTime = ((dGreenwichMeanSiderealTime * 15 * Math.PI) / 180.0
                + udtLocation.getLongitude());
        dHourAngle = dLocalMeanSiderealTime - dRightAscension[0];
        dLatitudeInRadians = udtLocation.getLatitude();
        dCos_Latitude = Math.cos(dLatitudeInRadians);
        dSin_Latitude = Math.sin(dLatitudeInRadians);
        dCos_HourAngle = Math.cos(dHourAngle);
        var za = (Math.acos(dCos_Latitude * dCos_HourAngle
                * Math.cos(dDeclination[0]) + Math.sin(dDeclination[0]) * dSin_Latitude));
        udtSunCoordinates.setZenithAngle(za);
        dY = -Math.sin(dHourAngle);
        dX = Math.tan(dDeclination[0]) * dCos_Latitude - dSin_Latitude * dCos_HourAngle;
        udtSunCoordinates.setAzimuth(Math.atan2(dY, dX));
        if (udtSunCoordinates.getAzimuth() < 0.0) {
            udtSunCoordinates.setAzimuth(udtSunCoordinates.getAzimuth() + 2 * Math.PI);
        }
        // Parallax Correction
        dParallax = (dEarthMeanRadius / dAstronomicalUnit)
                * Math.sin(udtSunCoordinates.getZenithAngle());
        za = udtSunCoordinates.getZenithAngle()
                + dParallax;
        udtSunCoordinates.setZenithAngle(za);
    }


        static double dEarthMeanRadius = 6371.01;	// In km
        static double dAstronomicalUnit = 149597890;	// In km

}

