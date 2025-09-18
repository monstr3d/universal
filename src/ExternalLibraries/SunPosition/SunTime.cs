using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunPosition
{
    public static class SunTime
    {

        static double coeff = Math.PI / 360;
        public static double CalculateJulianDate(DateTime dateTimeUtc)
        {
            // This is a simplified calculation for demonstration.
            // For extreme precision, use more robust algorithms.
            double a = Math.Floor((12.0 - dateTimeUtc.Hour) / 24.0);
            double JD = 1721424.5 + dateTimeUtc.Day + Math.Floor((dateTimeUtc.Year - 1) / 4.0) - 
                Math.Floor((dateTimeUtc.Year - 1) / 100.0) + Math.Floor((dateTimeUtc.Year - 1) / 400.0) +
                Math.Floor(365.25 * (dateTimeUtc.Year + 4716)) + Math.Floor(30.6001 * (dateTimeUtc.Month + 1)) + 
                dateTimeUtc.Minute / 60.0 +
                dateTimeUtc.Second / 3600.0 + dateTimeUtc.Hour / 24.0 - a;
            return JD;
        }

        public static double CalculateGreenwichSiderealTime(DateTime dateTimeUtc)
        {
            var x = CalculateJulianDate(dateTimeUtc);
            x = CalculateJulianCentury(x);
            return CalculateGreenwichSiderealTime(x);
        }

        public static double CalculateJulianCentury(double julianDate)
        {
            // J2000.0 is Julian Date 2451545.0
            return (julianDate - 2451545.0) / 36525.0;
        }

        // This is a common approximation for GST. More precise formulas exist.
        public static double CalculateGreenwichSiderealTime(double julianCentury)
        {
            double gstDegrees = 280.46061837 + 360.98564736629 * julianCentury + 0.000387933 * Math.Pow(julianCentury, 2) - Math.Pow(julianCentury, 3) / 38710000.0;
            gstDegrees *= coeff;
            // Normalize to 0-360 range
            gstDegrees = gstDegrees % (2 * Math.PI); //% 360.0;
            if (gstDegrees < 0)
            {
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

        public static double ToJulianDayNumber(DateTime dateTime)
        {
            // Algorithm based on Meeus, Astronomical Algorithms, 2nd Ed., p. 60
            // This algorithm is for the Julian calendar and is valid for dates before 1582-10-15.
            // For dates on or after 1582-10-15 (Gregorian calendar), adjustments are needed.

            int Y = dateTime.Year;
            int M = dateTime.Month;
            int D = dateTime.Day;
            int h = dateTime.Hour;
            int m = dateTime.Minute;
            int s = dateTime.Second;

            // Adjust for months and years in the algorithm
            if (M < 3)
            {
                Y--;
                M += 12;
            }

            // Calculate integer part of Julian Day Number
            int A = Y / 100;
            int B = A / 4;
            int C = (int)(2 - A + B); // Use cast to double for precision

            double JD0 = (int)(365.25 * (Y + 4716)) + (int)(30.6001 * (M + 1)) + D + C - 1524.5;

            // Add fractional part for time
            double jd = JD0 + (h + m / 60.0 + s / 3600.0) / 24.0;

            // --- Gregorian Calendar Adjustment ---
            // This adjustment is crucial for dates on or after October 15, 1582
            if (dateTime.Ticks >= new DateTime(1582, 10, 15).Ticks)
            {
                double G = A - B;
                jd = JD0 + G - 2400000.5 + (h + m / 60.0 + s / 3600.0) / 24.0;
            }

            return jd;
        }

        /// <summary>
        /// Converts a Julian Day Number back to a DateTime.
        /// </summary>
        /// <param name="julianDayNumber">The Julian Day Number to convert.</param>
        /// <returns>The corresponding DateTime.</returns>
        public static DateTime FromJulianDayNumber(double julianDayNumber)
        {
            // Algorithm based on Meeus, Astronomical Algorithms, 2nd Ed., p. 62
            // This algorithm also needs to handle the Gregorian calendar switch.

            double Z = Math.Floor(julianDayNumber + 0.5); // Integer part of the Julian Day Number
            double F = julianDayNumber + 0.5 - Z;        // Fractional part

            double A, B, C, D, E;

            // Adjust for Gregorian calendar
            if (Z < 2299161) // Julian calendar
            {
                A = Z;
            }
            else // Gregorian calendar
            {
                A = Math.Floor((Z - 1867216.25) / 36524.25);
                B = 2 + A - Math.Floor(A / 4);
                A = Z + B;
            }

            // Calculate components
            B = A + 1524;
            C = Math.Floor((B - 122.1) / 365.25);
            D = Math.Floor(365.25 * C);
            E = Math.Floor((B - D) / 30.6001);

            // Calculate Day, Month, and Year
            int day = (int)(B - D - Math.Floor(30.6001 * E));
            int month = (int)(E < 14 ? E - 1 : E - 13);
            int year = (int)(C - 4716 + (month > 2 ? 1 : 0));

            // Calculate Hour, Minute, Second from fractional part
            double timeFraction = F * 24.0;
            int hour = (int)Math.Floor(timeFraction);
            double minuteFraction = (timeFraction - hour) * 60.0;
            int minute = (int)Math.Floor(minuteFraction);
            double secondFraction = (minuteFraction - minute) * 60.0;
            int second = (int)Math.Round(secondFraction); // Round to nearest second

            // Construct the DateTime
            // Note: DateTime constructor doesn't handle days outside valid month/year.
            // The algorithm should ideally produce valid dates if input is correct.
            try
            {
                return new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Handle potential date construction errors if the algorithm has edge cases.
                // For most practical purposes, this should not be an issue with correct JDN input.
                Console.WriteLine($"Error creating DateTime from Julian Day Number {julianDayNumber}: {ex.Message}");
                // You might want to return DateTime.MinValue or throw a custom exception
                return DateTime.MinValue;
            }
        }

    }
}
