"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SunTime = void 0;
class SunTime {
    constructor() {
        this.coeff = Math.PI / 360.0;
    }
    CalculateGreenwichSiderealTimeFromDate(dateTimeUtc) {
        let x = this.CalculateJulianDate(dateTimeUtc);
        x = this.CalculateJulianCentury(x);
        x = this.CalculateGreenwichSiderealTime(x);
        return x;
    }
    CalculateJulianDate(dateTimeUtc) {
        // This is a simplified calculation for demonstration.
        // For extreme precision, use more robust algorithms.
        let h = dateTimeUtc.getHours();
        let y = dateTimeUtc.getFullYear();
        let m = dateTimeUtc.getMonth() + 1;
        let mm = dateTimeUtc.getMinutes();
        let s = dateTimeUtc.getSeconds();
        let ms = dateTimeUtc.getMilliseconds();
        let d = dateTimeUtc.getDate();
        var a = Math.floor((12.0 - h) / 24.0);
        var JD = 1721424.5 + d +
            Math.floor((y - 1) / 4.0)
            - Math.floor((y - 1) / 100.0) +
            Math.floor((y - 1) / 400.0) +
            Math.floor(365.25 * (y + 4716)) +
            Math.floor(30.6001 * (m + 1)) +
            mm / 60.0 +
            s / 3600.0 + h / 24.0
            + ms / 3600000.0
            - a;
        return JD;
    }
    CalculateJulianCentury(julianDate) {
        // J2000.0 is Julian Date 2451545.0
        return (julianDate - 2451545.0) / 36525.0;
    }
    // This is a common approximation for GST. More precise formulas exist.
    CalculateGreenwichSiderealTime(julianCentury) {
        let gstDegrees = 280.46061837 + 360.98564736629 * julianCentury + 0.000387933 *
            Math.pow(julianCentury, 2) - Math.pow(julianCentury, 3) / 38710000.0;
        gstDegrees *= this.coeff;
        // Normalize to 0-360 range
        gstDegrees = gstDegrees % (2 * Math.PI); //% 360.0;
        if (gstDegrees < 0) {
            gstDegrees += 2 * Math.PI;
        }
        return gstDegrees;
    }
}
exports.SunTime = SunTime;
//# sourceMappingURL=SunTime.js.map