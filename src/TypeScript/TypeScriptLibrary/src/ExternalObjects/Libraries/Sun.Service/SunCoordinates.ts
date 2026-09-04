export class SunCoordinates {

    private azimuth: number = 0;

    private zenithAngle: number = 0;



    public getAzimuth(): number {
        return this.azimuth;
    }

    public setAzimuth(azimuth: number): void {
        this.azimuth = azimuth;
    }

    public getZenithAngle(): number {
        return this.zenithAngle;

    }

    public setZenithAngle(zenithAngle: number): void {
        this.zenithAngle = zenithAngle;
    }

}