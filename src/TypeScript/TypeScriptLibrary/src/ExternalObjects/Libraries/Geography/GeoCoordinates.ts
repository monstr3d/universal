export class GeoCoordinates {


    private longitude: number = 0;

    private latitude: number = 0;



    public getLongitude(): number {
        return this.longitude;
    }

    public setLongitude(longitude: number) : void {
        this.longitude = longitude;
    }

    public getLatitude(): number {
        return this.latitude;

    }

    public setLatitude(latitude: number) {
        this.latitude = latitude;
    }
}