import { GeoCoordinates } from "../Geography/GeoCoordinates";
import { SunCoordinates } from "./SunCoordinates";

export class SunPosition {
    public convertToJulian(date: Date): number {
        let Day = date.getDate();
        let Month = date.getMonth() + 1;
        let Year = date.getFullYear();
        if (Month < 3)
        {
            Month = Month + 12;
            Year = Year - 1;
        }
        let JulianDay = Day + Math.floor((153 * Month - 457) / 5) + 365 * Year + Math.floor((Year / 4)) - Math.floor((Year / 100)) + Math.floor( (Year / 400)) + 1721119;
        return JulianDay;
    }

    /// <summary>
    /// Gets position of Sun
    /// </summary>
    /// <param name="time"></param>
    /// <param name="dDeclination"></param>
    /// <param name="dRightAscension"></param>
    public  getPositionFull(time : Date,
     dDeclination : number[], dRightAscension : number[],
dElapsedJulianDays:  number[],
        dDecimalHours: number[]): void{
        var h = time.getHours();
        var m = time.getMinutes();
        var s = time.getSeconds();

 
        var ss = s / 60.0;

        var mm = (m + ss) / 60;

        dDecimalHours[0] = h + ss + mm;


        dElapsedJulianDays[0] = this.convertToJulian(time) - 0.5 - 2451545.0 + dDecimalHours[0] / 24.0;

        // Calculate ecliptic coordinates (ecliptic longitude and obliquity of the
        // ecliptic in radians but without limiting the angle to be less than 2*Pi
        // (i.e., the result may be greater than 2*Pi)
        let dMeanLongitude = 0;
        let dMeanAnomaly = 0;;
        let dOmega = 2.1429 - 0.0010394594 * dElapsedJulianDays[0];
        dMeanLongitude = 4.8950630 + 0.017202791698 * dElapsedJulianDays[0]; // Radians
        dMeanAnomaly = 6.2400600 + 0.0172019699 * dElapsedJulianDays[0];
       let dEclipticLongitude = dMeanLongitude + 0.03341607 * Math.sin(dMeanAnomaly)
            + 0.00034894 * Math.sin(2 * dMeanAnomaly) - 0.0001134
            - 0.0000203 * Math.sin(dOmega);
        let dEclipticObliquity = 0.4090928 - 6.2140e-9 * dElapsedJulianDays[0]
            + 0.0000396 * Math.cos(dOmega);

        // Calculate celestial coordinates ( right ascension and declination ) in radians
        // but without limiting the angle to be less than 2*Pi (i.e., the result may be
        // greater than 2*Pi)

        let dSin_EclipticLongitude = Math.sin(dEclipticLongitude);
        let dY = Math.cos(dEclipticObliquity) * dSin_EclipticLongitude;
        let dX = Math.cos(dEclipticLongitude);
        dRightAscension[0] = Math.atan2(dY, dX);
        if (dRightAscension[0] < 0.0)
        {
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
    public getPosition(udtTime: Date, udtLocation: GeoCoordinates, udtSunCoordinates: SunCoordinates,
        dDeclination: number[], dRightAscension: number[], dElapsedJulianDays: number[], dDecimalHours: number[]) {
        // Auxiliary variables
     
        this.getPositionFull(udtTime, dDeclination, dRightAscension,
            dElapsedJulianDays, dDecimalHours);

  
       let  dGreenwichMeanSiderealTime = 6.6974243242 +
            0.0657098283 * dElapsedJulianDays[0]
            + dDecimalHours[0];
       let  dLocalMeanSiderealTime = ((dGreenwichMeanSiderealTime * 15 * Math.PI) / 180.0
            + udtLocation.getLongitude());
        let dHourAngle = dLocalMeanSiderealTime - dRightAscension[0];
        let dLatitudeInRadians = udtLocation.getLatitude();
        let dCos_Latitude = Math.cos(dLatitudeInRadians);
        let dSin_Latitude = Math.sin(dLatitudeInRadians);
        let dCos_HourAngle = Math.cos(dHourAngle);
        let za = (Math.acos(dCos_Latitude * dCos_HourAngle
            * Math.cos(dDeclination[0]) + Math.sin(dDeclination[0]) * dSin_Latitude));
        udtSunCoordinates.setZenithAngle(za);
       let  dY = -Math.sin(dHourAngle);
       let  dX = Math.tan(dDeclination[0]) * dCos_Latitude - dSin_Latitude * dCos_HourAngle;
        udtSunCoordinates.setAzimuth(Math.atan2(dY, dX));
        if (udtSunCoordinates.getAzimuth() < 0.0)
        {
            udtSunCoordinates.setAzimuth(udtSunCoordinates.getAzimuth() + 2 * Math.PI);
        }
        // Parallax Correction
       let  dParallax = (this.dEarthMeanRadius / this.dAstronomicalUnit)
            * Math.sin(udtSunCoordinates.getZenithAngle());
        za = udtSunCoordinates.getZenithAngle()
            + dParallax;
        udtSunCoordinates.setZenithAngle(za);
    }

    dEarthMeanRadius: number = 6371.01;	// In km
    dAstronomicalUnit: number = 149597890;	// In km

}