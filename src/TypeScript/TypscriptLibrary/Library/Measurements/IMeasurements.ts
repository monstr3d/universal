/**
 * 
 */
interface IMeasurements {
    getCount(): number;
    get(i: number): IMeasurement;
    Update(): void;

}