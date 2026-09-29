package external.utilities.date_time;

import java.time.Duration;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;

public class OADateConverter {


    static  int msPerDay = 24 * 60 * 60 * 1000;

    static  long msPerNano =   24 * 60 * 60 * 1_000_000_000L;

    static double nanoInvert;

    static {
        var a = (double) msPerNano;
        nanoInvert = 1.0 / a;
    }

    // The epoch for Ole Automation Date (December 30, 1899, 00:00:00);
    private static final LocalDateTime OADATE_EPOCH = LocalDateTime.of(1899, 12, 30, 0, 0, 0);

    public static double toOADate(LocalDateTime oaDate)
    {
        Duration duration = Duration.between(OADATE_EPOCH, oaDate);
        long n =  duration.toNanos();
        return (double)n * nanoInvert;
    }

    /**
     * Converts an Ole Automation Date (OADate) double to a Java LocalDateTime.
     *
     * @param oaDate The OADate double to convert.
     * @return The corresponding LocalDateTime.
     */
    public static LocalDateTime fromOADate(double oaDate) {
        // Handle potential NaN or Infinity values gracefully if needed
        if (Double.isNaN(oaDate) || Double.isInfinite(oaDate)) {
            // Or throw an IllegalArgumentException
            return null;
        }

        // The integer part of the OADate is the number of days since the epoch.
        long days = (long) oaDate;

        // The fractional part is the time of day.
        // We multiply by 24 to get hours, then by 60 for minutes, and so on.
        double fractionalPart = oaDate - days;
        long totalSeconds = (long) (fractionalPart * 24 * 60 * 60);

        // Create the LocalDateTime by adding the calculated duration to the epoch.
        LocalDateTime result = OADATE_EPOCH.plusDays(days);

        // Add the time component
        // We need to be careful with precision here.
        // Let's extract hours, minutes, seconds, and nanoseconds.

        long hours = totalSeconds / 3600;
        long remainingSecondsAfterHours = totalSeconds % 3600;
        long minutes = remainingSecondsAfterHours / 60;
        long seconds = remainingSecondsAfterHours % 60;

        // For nanoseconds, we can use the fractional part directly.
        // fractionalPart * 24 * 60 * 60 * 1_000_000_000
        long nanoseconds = (long) ((oaDate - (long)oaDate) * 86400000000000L);


        // Adjust for the fact that OADate epoch is midnight, but we need to add time components separately.
        // The `plus` method handles the addition of days and then we add the time.
        return result.plusHours(hours)
                .plusMinutes(minutes)
                .plusSeconds(seconds)
                .plusNanos(nanoseconds % 1_000_000_000); // Ensure nanoseconds are within the valid range
    }
/*
    public static void main(String[] args) {
        // Example usage:
        // OADate for January 1, 2000, 12:00:00 PM
        // Days from 1899-12-30 to 1999-12-30 is 36525 (including leap years)
        // Additional days to 2000-01-01 is 2
        // Total whole days = 36525 + 2 = 36527
        // 12:00:00 PM is 0.5 of a day
        double oaDate1 = 36527.5;
        LocalDateTime dateTime1 = fromOADate(oaDate1);
        System.out.println("OADate: " + oaDate1 + " -> LocalDateTime: " + dateTime1); // Expected: 2000-01-01T12:00

        // OADate for December 31, 1899, 06:00:00 AM
        // Days = 0, Time = 0.25 (6 AM is 1/4 of a day)
        double oaDate2 = 0.25;
        LocalDateTime dateTime2 = fromOADate(oaDate2);
        System.out.println("OADate: " + oaDate2 + " -> LocalDateTime: " + dateTime2); // Expected: 1899-12-30T06:00

        // OADate for January 1, 1900, 00:00:00 AM (Note: OADate has a quirk where 1900 is treated as a leap year by Excel, though it wasn't historically)
        // Days = 1 (from 1899-12-30 to 1900-01-01)
        double oaDate3 = 1.0;
        LocalDateTime dateTime3 = fromOADate(oaDate3);
        System.out.println("OADate: " + oaDate3 + " -> LocalDateTime: " + dateTime3); // Expected: 1900-01-01T00:00

        // OADate for January 1, 1900, 18:00:00 PM (6 PM)
        // Days = 1, Time = 0.75
        double oaDate4 = 1.75;
        LocalDateTime dateTime4 = fromOADate(oaDate4);
        System.out.println("OADate: " + oaDate4 + " -> LocalDateTime: " + dateTime4); // Expected: 1900-01-01T18:00

        // Example with very small fractional part
        double oaDate5 = 36527.00001;
        LocalDateTime dateTime5 = fromOADate(oaDate5);
        System.out.println("OADate: " + oaDate5 + " -> LocalDateTime: " + dateTime5);
    }*/
}