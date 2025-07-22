import { IMeasurement } from "./IMeasurement";

export interface IMeasurements
{
    getMeasurementsCount(): number;
    getMeasurement(i: number): IMeasurement;
    updateMeasurements(): void;
    addMeasurement(measurement: IMeasurement): void;

}