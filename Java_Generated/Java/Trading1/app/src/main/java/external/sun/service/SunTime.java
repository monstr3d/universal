package external.sun.service;


import java.time.Duration;
import java.time.LocalDateTime;

public class SunTime {

    static double coeff = Math.PI / 360;

    public static double CalculateJulianDate(LocalDateTime dateTimeUtc)
    {
        // This is a simplified calculation for demonstration.
        // For extreme precision, use more robust algorithms.
        double a = Math.floor((12.0 - dateTimeUtc.getHour()) / 24.0);
        double JD = 1721424.5 + dateTimeUtc.getDayOfMonth() +
                Math.floor((dateTimeUtc.getYear() - 1) / 4.0)
                - Math.floor((dateTimeUtc.getYear() - 1) / 100.0) +
                Math.floor((dateTimeUtc.getYear() - 1) / 400.0) +
                Math.floor(365.25 * (dateTimeUtc.getYear()+ 4716)) +
                Math.floor(30.6001 * (dateTimeUtc.getMonthValue() + 1)) +
                dateTimeUtc.getMinute() / 60.0 +
                dateTimeUtc.getSecond() / 3600.0 + dateTimeUtc.getHour()/ 24.0
                + dateTimeUtc.getNano() / 3600000000000.0
                - a;
        return JD;
    }

    public static double CalculateGreenwichSiderealTime(LocalDateTime dateTimeUtc)
    {
        var x = CalculateJulianDate(dateTimeUtc);
        x = CalculateJulianCentury(x);
        x =  CalculateGreenwichSiderealTime(x);
        return x;
    }

    public static double CalculateJulianCentury(double julianDate)
    {
        // J2000.0 is Julian Date 2451545.0
        return (julianDate - 2451545.0) / 36525.0;
    }

    // This is a common approximation for GST. More precise formulas exist.
    public static double CalculateGreenwichSiderealTime(double julianCentury) {
        double gstDegrees = 280.46061837 + 360.98564736629 * julianCentury + 0.000387933 *
                Math.pow(julianCentury, 2) - Math.pow(julianCentury, 3) / 38710000.0;
        gstDegrees *= coeff;
        // Normalize to 0-360 range
        gstDegrees = gstDegrees % (2 * Math.PI); //% 360.0;
        if (gstDegrees < 0) {
            gstDegrees += 2 * Math.PI;
        }
        return gstDegrees;
    }

    public static double CalculateLocalSiderealTimeHours(double gstHours, double longitudeDegrees)
    {
        double lstHours = gstHours + (longitudeDegrees / 15.0); // Convert longitude to hours

        // Normalize to 0-24 range
        lstHours = lstHours % 24.0;
        if (lstHours < 0)
        {
            lstHours += 24.0;
        }
        return lstHours;
    }

    public static double ToJulianDayNumber(LocalDateTime dateTime)
    {
        // Algorithm based on Meeus, Astronomical Algorithms, 2nd Ed., p. 60
        // This algorithm is for the Julian calendar and is valid for dates before 1582-10-15.
        // For dates on or after 1582-10-15 (Gregorian calendar), adjustments are needed.

        int Y = dateTime.getYear();
        int M = dateTime.getMonthValue();
        int D = dateTime.getDayOfMonth();
        int h = dateTime.getHour();
        int m = dateTime.getMinute();
        int s = dateTime.getSecond();

        // Adjust for months and years in the algorithm
        if (M < 3)
        {
            Y--;
            M += 12;
        }

        // Calculate integer part of Julian Day Number
        int A = Y / 100;
        int B = A / 4;
        int C = 2 - A + B; // Use cast to double for precision

        double JD0 = (int)(365.25 * (Y + 4716)) + (int)(30.6001 * (M + 1)) + D + C - 1524.5;

        // Add fractional part for time
        double jd = JD0 + (h + m / 60.0 + s / 3600.0) / 24.0;
        var dur = Duration.between(dt1582, dateTime);

        // --- Gregorian Calendar Adjustment ---
        // This adjustment is crucial for dates on or after October 15, 1582
        if (!dur.isNegative())
        {
            double G = A - B;
            jd = JD0 + G - 2400000.5 + (h + m / 60.0 + s / 3600.0) / 24.0;
        }

        return jd;
    }

    private static final LocalDateTime  dt1582 = LocalDateTime.of(1582, 10, 15, 0, 0);




    /// <summary>
    /// Converts a Julian Day Number back to a DateTime.
    /// </summary>
    /// <param name="julianDayNumber">The Julian Day Number to convert.</param>
    /// <returns>The corresponding DateTime.</returns>
    public static LocalDateTime FromJulianDayNumber(double julianDayNumber)
    {
        // Algorithm based on Meeus, Astronomical Algorithms, 2nd Ed., p. 62
        // This algorithm also needs to handle the Gregorian calendar switch.

        double Z = Math.floor(julianDayNumber + 0.5); // Integer part of the Julian Day Number
        double F = julianDayNumber + 0.5 - Z;        // Fractional part

        double A, B, C, D, E;

        // Adjust for Gregorian calendar
        if (Z < 2299161) // Julian calendar
        {
            A = Z;
        }
        else // Gregorian calendar
        {
            A = Math.floor((Z - 1867216.25) / 36524.25);
            B = 2 + A - Math.floor(A / 4);
            A = Z + B;
        }

        // Calculate components
        B = A + 1524;
        C = Math.floor((B - 122.1) / 365.25);
        D = Math.floor(365.25 * C);
        E = Math.floor((B - D) / 30.6001);

        // Calculate Day, Month, and Year
        int day = (int)(B - D - Math.floor(30.6001 * E));
        int month = (int)(E < 14 ? E - 1 : E - 13);
        int year = (int)(C - 4716 + (month > 2 ? 1 : 0));

        // Calculate Hour, Minute, Second from fractional part
        double timeFraction = F * 24.0;
        int hour = (int)Math.floor(timeFraction);
        double minuteFraction = (timeFraction - hour) * 60.0;
        int minute = (int)Math.floor(minuteFraction);
        double secondFraction = (minuteFraction - minute) * 60.0;
        int second = (int)Math.round(secondFraction); // Round to nearest second

        // Construct the DateTime
        // Note: DateTime constructor doesn't handle days outside valid month/year.
        // The algorithm should ideally produce valid dates if input is correct.
             return  LocalDateTime.of(year, month, day, hour, minute, second);
     }
}
