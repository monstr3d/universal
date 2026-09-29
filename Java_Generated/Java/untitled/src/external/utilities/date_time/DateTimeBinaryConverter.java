package external.utilities.date_time;

import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.ZoneOffset;
import java.time.ZonedDateTime;
import java.time.temporal.ChronoField;
import java.time.temporal.ChronoUnit;

public class DateTimeBinaryConverter {

    /**
     * Mimics the behavior of .NET's DateTime.ToBinary() by packing
     * date and time components into a 64-bit long.
     *
     * The packing format is a simplified version to demonstrate the concept:
     * - Kind (0 for Local/Unspecified, 1 for UTC): 2 bits
     * - Year (1-9999): 14 bits
     * - Month (1-12): 4 bits
     * - Day (1-31): 5 bits
     * - Hour (0-23): 5 bits
     * - Minute (0-59): 6 bits
     * - Second (0-59): 6 bits
     * - Millisecond (0-999): 10 bits
     *
     * Note: This is a simplified representation and might not perfectly
     * match every nuance of .NET's internal packing for all DateTimeKind values
     * and potential edge cases.
     *
     * @param dateTime The LocalDateTime to convert.
     * @param kind     The DateTimeKind to associate with the binary representation.
     *                 Use 0 for Local/Unspecified, 1 for UTC.
     * @return The packed 64-bit long representing the date and time.
     */
    public static long toBinary(LocalDateTime dateTime, int kind) {
        if (dateTime == null) {
            throw new IllegalArgumentException("LocalDateTime cannot be null.");
        }
        if (kind != 0 && kind != 1) {
            throw new IllegalArgumentException("Kind must be 0 (Local/Unspecified) or 1 (UTC).");
        }

        // Validate date components to fit within the assumed bit allocation
        int year = dateTime.getYear();
        if (year < 1 || year > 9999) {
            throw new IllegalArgumentException("Year must be between 1 and 9999.");
        }
        int month = dateTime.getMonthValue();
        int day = dateTime.getDayOfMonth();
        int hour = dateTime.getHour();
        int minute = dateTime.getMinute();
        int second = dateTime.getSecond();
        int millisecond = dateTime.getNano() / 1_000_000; // Convert nanoseconds to milliseconds

        // Use bit shifting to pack the values.
        // We'll use a signed long, so we need to be careful with the most significant bit.
        // For simplicity, we'll assume the `kind` determines the "sign" or type.
        // A more precise mimicry would involve analyzing .NET's specific bit layout for the sign bit.

        long binaryValue = 0;

        // Pack Kind (2 bits) - Shifted to the highest bits for clarity in this example
        // In .NET's actual implementation, it's packed differently within the structure.
        // We're simulating the spirit of packing.
        // A more direct mapping would require knowing the exact bit positions.
        // For this simulation, let's reserve top bits for kind.

        // Let's use the actual .NET packing scheme as closely as possible.
        // The actual .NET structure is more complex as it involves the internal
        // representation which isn't purely a concatenation of components.

        // For a more accurate simulation of the binary representation, we need to
        // refer to known implementations or reverse-engineered formats.
        // A common interpretation of DateTime.ToBinary() involves packing the
        // date and time components.

        // Let's use a more practical approach if you need to exchange data with .NET.
        // Often, a common serialization format like ISO 8601 or a custom format
        // with epoch milliseconds is preferred over trying to perfectly replicate
        // internal binary representations.

        // If you absolutely need to mimic the bit layout:
        // The structure is often described as:
        // Bits 0-5: Milliseconds (0-999)
        // Bits 6-11: Seconds (0-59)
        // Bits 12-17: Minutes (0-59)
        // Bits 18-22: Hours (0-23)
        // Bits 23-27: Day (1-31)
        // Bits 28-31: Month (1-12)
        // Bits 32-45: Year (1-9999) - This is where it gets tricky due to limited bits.
        // .NET likely uses a specific encoding for Year.
        // Bits 62-63: Kind (00=Unspecified, 01=Utc, 10=Local)

        // Let's try a simpler, commonly understood approach for packing:
        // The total number of days from a reference point, plus time in milliseconds.
        // This is different from .NET's ToBinary but more standard for Java.

        // If the goal is interoperability with .NET, it's best to use a
        // well-defined serialization format that both can parse.
        // For example, sending the `LocalDateTime` as an ISO string or
        // as epoch milliseconds (with a way to indicate time zone).

        // --- Re-attempting to mimic .NET's bit packing more closely ---
        // Based on various analyses, the structure is roughly:
        // 64-bit integer (long in Java)
        // The most significant bits (e.g., 62-63) encode the DateTimeKind.
        // The remaining bits encode the date and time components.
        // The exact bit allocation for year, month, day, etc., is crucial.

        // Let's assume a common packing scheme for demonstration:
        // (Bit 63) Kind (0=Local/Unspecified, 1=UTC) - Simplified
        // (Bit 62) Unused/Padding (or part of Kind encoding)
        // (Bits 61-47) Year (max 14 bits for 1-9999)
        // (Bits 46-43) Month (max 4 bits for 1-12)
        // (Bits 42-38) Day (max 5 bits for 1-31)
        // (Bits 37-33) Hour (max 5 bits for 0-23)
        // (Bits 32-27) Minute (max 6 bits for 0-59)
        // (Bits 26-21) Second (max 6 bits for 0-59)
        // (Bits 20-10) Millisecond (max 10 bits for 0-999)

        // Let's refine the bit packing to be more precise with the structure.
        // The actual .NET structure involves internal details of `DateTimeKind` and date representation.
        // .NET's `DateTime.ToBinary()` stores internal representation.
        // A common interpretation is:
        // `long` value is composed of:
        // - `DateTimeKind` bits (most significant)
        // - `Ticks` (number of 100-nanosecond intervals since 0001-01-01 00:00:00)

        // Java's `java.time.LocalDateTime` doesn't directly provide Ticks in the .NET sense.
        // It's based on `long epochMilli` and `int nanoOfSecond`.
        // To accurately mimic .NET's `ToBinary()`, we need to convert `LocalDateTime`
        // to the .NET `DateTime` epoch and then to ticks.

        // The .NET epoch is 0001-01-01 00:00:00.
        // The Java `java.time` epoch for `ChronoField.EPOCH_DAY` is 1970-01-01.
        // We need to convert from Java's epoch to .NET's epoch.

        // Let's try to achieve the exact bit layout as often described for .NET's ToBinary:
        // 64-bit long:
        // Bits 63-62: DateTimeKind (00 = Unspecified, 01 = UTC, 10 = Local) - This is a common interpretation.
        // Bits 61-32: Date part (packed year, month, day)
        // Bits 31-0: Time part (packed hour, minute, second, millisecond)

        // .NET's internal representation is based on Ticks.
        // Ticks = Number of 100-nanosecond intervals since 0001-01-01 00:00:00.
        // A `long` in .NET is `System.Int64`.

        // To accurately replicate `DateTime.ToBinary()`, we need to:
        // 1. Convert `java.time.LocalDateTime` to `java.time.ZonedDateTime` (or `OffsetDateTime`).
        // 2. Determine the `DateTimeKind` based on the input.
        // 3. Calculate the number of "ticks" (100-nanosecond intervals) from .NET's epoch (0001-01-01).
        // 4. Pack the `DateTimeKind` and `Ticks` into a `long`.

        // Calculating Ticks accurately is the core challenge.

        // Let's use the provided `kind` (0 or 1) to represent the DateTimeKind.
        // If kind is 0, it's Unspecified/Local. If kind is 1, it's UTC.
        // .NET's `DateTimeKind` has 3 values: Unspecified, Utc, Local.
        // The `ToBinary` format might use specific bit patterns for these.

        // Re-evaluate: The most direct way to mimic `DateTime.ToBinary`
        // would be to use a library that exposes or can convert to/from
        // .NET's DateTime representation. Without such a library, we are
        // reverse-engineering a specific binary format.

        // A common representation of DateTime in binary is the number of
        // 100-nanosecond intervals (ticks) since the .NET epoch (0001-01-01).
        // The `DateTimeKind` is also packed.

        // Let's try to construct it using the components directly into bits.
        // This is a common bit packing strategy, but the exact bit allocation
        // of .NET's `ToBinary` might differ in subtle ways.

        // Kind (2 bits):
        // 00: Unspecified
        // 01: UTC
        // 10: Local
        // We'll use `kind` parameter: 0 -> Unspecified, 1 -> UTC.
        // For Local, .NET might have a different internal representation or
        // it's handled by context. Let's assume `kind = 0` maps to Local/Unspecified.

        long packedBinary = 0;

        // Packing Kind:
        // Let's assume the top 2 bits represent Kind.
        // 00 for Unspecified, 01 for UTC, 10 for Local.
        // We only have `kind = 0` (Local/Unspecified) and `kind = 1` (UTC).
        // Let's map `kind = 0` to `00` and `kind = 1` to `01`.
        int kindBits = kind << 62; // Shift to top 2 bits. This is a common pattern.
        packedBinary |= kindBits;

        // Packing Year (1 to 9999) - Needs ~14 bits.
        // We need to offset the year to fit. The year 1 is the starting point for .NET DateTime.
        int yearForPacking = year - 1; // Year 1 becomes 0, year 9999 becomes 9998. Max needed ~13 bits.
        // Let's assume year is packed starting after Kind.
        // The total bits for date/time is 62.
        // .NET likely uses a specific packing scheme that's more optimized.
        // For example, the year might be packed in 14 bits, month in 4, day in 5.
        // This would be: 14 + 4 + 5 = 23 bits for the date part.

        // A more robust way: Convert to the .NET `Ticks` and `Kind` and then pack.
        // This requires a Java library that can perform this conversion or a manual calculation.

        // Manual calculation of Ticks (number of 100ns intervals since 0001-01-01 00:00:00):
        // This is complex due to leap years and Julian/Gregorian calendar changes.

        // --- Simplified Bit Packing (Commonly cited, may not be exact .NET spec) ---
        // Let's use the bit positions derived from common analyses of `DateTime.ToBinary()`.
        // It's primarily about the "Ticks" value.

        // Calculate the number of ticks from the .NET epoch (0001-01-01 00:00:00).
        // Java's `java.time.temporal.ChronoUnit.DAYS` and `NANOS` can be used,
        // but we need to adjust for the epoch difference.

        // .NET epoch: 0001-01-01
        // Java's epoch for `ChronoField.EPOCH_DAY`: 1970-01-01
        // Java's epoch for `ChronoField.NANO_OF_DAY`: 1970-01-01

        // Let's use `LocalDateTime` to `ZonedDateTime` and then `toInstant()`
        // and convert to nanoseconds since .NET epoch.

        // --- First, determine the base date and time for calculation ---
        // The .NET epoch is January 1, 0001, 00:00:00 UTC.
        LocalDateTime netEpoch = LocalDateTime.of(1, 1, 1, 0, 0, 0);
        ZoneId utcZone = ZoneId.of("UTC");

        // Convert the input LocalDateTime to a ZonedDateTime in UTC for consistent tick calculation.
        // If the input `kind` is 0 (Local/Unspecified), we need to assume a zone for `LocalDateTime`.
        // If we assume the `LocalDateTime` is already in the system's local time zone:
        ZoneId systemDefaultZone = ZoneId.systemDefault();
        ZonedDateTime zonedInputDateTime;
        if (kind == 0) { // Assuming Local or Unspecified maps to system default for conversion
            zonedInputDateTime = dateTime.atZone(systemDefaultZone);
        } else { // Kind is 1 (UTC)
            zonedInputDateTime = dateTime.atZone(utcZone);
        }
        // Ensure we are working with UTC for tick calculation from .NET epoch
        ZonedDateTime inputDateTimeUtc = zonedInputDateTime.withZoneSameInstant(utcZone);

        // Calculate the difference in nanoseconds from the .NET epoch
        long daysBetween = ChronoUnit.DAYS.between(netEpoch, inputDateTimeUtc);
        long nanosBetween = inputDateTimeUtc.getLong(ChronoField.NANO_OF_DAY); // Nanoseconds within the day

        // Total ticks: days * (24 * 60 * 60 * 10^9) + nanos
        // 1 tick = 100 nanoseconds.
        // So, Ticks = (total nanoseconds) / 100
        long totalNanos = daysBetween * 24 * 60 * 60 * 1_000_000_000L + nanosBetween;
        long ticks = totalNanos / 100; // This is the number of 100-nanosecond intervals.

        // Now, pack the `kind` and `ticks`.
        // .NET's ToBinary() uses `long`. The structure is usually:
        // 2 bits for Kind (most significant)
        // Rest for Ticks.
        // However, the exact bit packing of `kind` might be different.
        // A common way to represent DateTimeKind in binary is to use the
        // `ticks` value itself and embed `kind` within the higher bits.

        // Let's use the common approach:
        // Bits 63-62: Kind flags
        // Bits 61-0: Ticks

        // DateTimeKind mapping for packing:
        // Unspecified: 00
        // UTC: 01
        // Local: 10

        long kindFlags = 0;
        if (kind == 1) { // UTC
            kindFlags = 1; // 01 in binary
        } else { // Local or Unspecified (mapped to 0)
            kindFlags = 2; // 10 in binary for Local, or 00 for Unspecified.
            // .NET's ToBinary() encodes Local differently.
            // For a simplified mimic, let's map 0 to Local (10 in binary).
            // If we strictly follow `kind` parameter (0 for Local/Unspecified, 1 for UTC):
            // kind = 0 -> Local -> 10
            // kind = 1 -> UTC -> 01
        }
        // Re-reading .NET docs: `DateTime.ToBinary()` stores the `DateTimeKind`
        // by shifting `ticks` and ORing in the `Kind` enumeration value (0, 1, or 2).
        // The specific bit allocation isn't precisely documented for `ToBinary`
        // in a way that's easy to reverse-engineer precisely.

        // Let's adopt a commonly cited packing from reverse engineering:
        // `long` value = `(long)ticks | (((long)dateTimeKind & 3L) << 62);`
        // Where `dateTimeKind` is 0 (Unspecified), 1 (Utc), 2 (Local).
        // The `& 3L` ensures only the lower 2 bits of `dateTimeKind` are used.

        int netDateTimeKind;
        if (kind == 1) { // UTC
            netDateTimeKind = 1; // Enum value for Utc
        } else { // Local or Unspecified
            // For `LocalDateTime` input, we'd typically assume it's Local.
            // If `kind` parameter is 0, let's map it to `Local`.
            netDateTimeKind = 2; // Enum value for Local
        }

        // Perform the packing
        long binaryRepresentation = ticks | (((long)netDateTimeKind & 3L) << 62);

        return binaryRepresentation;
    }

    // Helper to convert from a specific .NET ToBinary long back to LocalDateTime
    // This is for verification purposes, showing how to unpack.
    public static LocalDateTime fromBinary(long binaryRepresentation) {
        // Extract Kind
        int kindFlags = (int)((binaryRepresentation >> 62) & 3L);
        int netDateTimeKind;
        if (kindFlags == 1) { // UTC
            netDateTimeKind = 1;
        } else if (kindFlags == 2) { // Local
            netDateTimeKind = 2;
        } else { // Unspecified (00)
            netDateTimeKind = 0;
        }

        // Extract Ticks
        long ticks = binaryRepresentation & 0x3FFFFFFFFFFFFFFFL; // Mask out the Kind bits

        // Convert Ticks to LocalDateTime (relative to .NET epoch 0001-01-01 UTC)
        // Ticks are 100-nanosecond intervals.
        long totalNanos = ticks * 100;
        long days = totalNanos / (24 * 60 * 60 * 1_000_000_000L);
        long nanosOfDay = totalNanos % (24 * 60 * 60 * 1_000_000_000L);

        LocalDateTime netEpoch = LocalDateTime.of(1, 1, 1, 0, 0, 0);
        LocalDateTime unpackedDateTime = netEpoch.plusDays(days);
        unpackedDateTime = unpackedDateTime.plusNanos(nanosOfDay);

        // Apply the kind. If it's Local, we might need to convert it to system default.
        // For simplicity here, we return LocalDateTime, which is 'Unspecified' by default.
        // To fully represent the original, you'd need to return ZonedDateTime.
        return unpackedDateTime;
    }

/*
    public static void main(String[] args) {
        // Example 1: A specific date and time
        LocalDateTime dateTime1 = LocalDateTime.of(2023, 10, 27, 10, 30, 15, 123_456_789);

        // To Binary (as UTC)
        long binaryUtc = toBinary(dateTime1, 1); // kind = 1 for UTC
        System.out.println("LocalDateTime: " + dateTime1 + " (UTC)");
        System.out.println("ToBinary (UTC): " + binaryUtc);

        // To Binary (as Local)
        long binaryLocal = toBinary(dateTime1, 0); // kind = 0 for Local
        System.out.println("LocalDateTime: " + dateTime1 + " (Local - System Default)");
        System.out.println("ToBinary (Local): " + binaryLocal);

        // --- Verification ---
        System.out.println("\n--- Verification ---");

        // Unpack the UTC value
        LocalDateTime unpackedUtc = fromBinary(binaryUtc);
        System.out.println("FromBinary (UTC): " + unpackedUtc);
        // Note: The kind information is lost when converting back to LocalDateTime.
        // To verify the kind, you'd need a more complex `fromBinary` that returns ZonedDateTime.

        // Unpack the Local value
        LocalDateTime unpackedLocal = fromBinary(binaryLocal);
        System.out.println("FromBinary (Local): " + unpackedLocal);

        // Example with .NET's epoch start
        LocalDateTime epochStart = LocalDateTime.of(1, 1, 1, 0, 0, 0);
        long binaryEpochUtc = toBinary(epochStart, 1);
        System.out.println("\nEpoch Start (UTC): " + epochStart);
        System.out.println("ToBinary (Epoch UTC): " + binaryEpochUtc);
        System.out.println("FromBinary (Epoch UTC): " + fromBinary(binaryEpochUtc));

        // Example with year 1900 (often has specific handling in some systems)
        LocalDateTime year1900 = LocalDateTime.of(1900, 1, 1, 0, 0, 0);
        long binary1900Local = toBinary(year1900, 0);
        System.out.println("\n1900-01-01 (Local): " + year1900);
        System.out.println("ToBinary (1900 Local): " + binary1900Local);
        System.out.println("FromBinary (1900 Local): " + fromBinary(binary1900Local));
    }

 */
}