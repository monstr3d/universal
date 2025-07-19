import { IMeasurement } from "./IMeasurement";

export interface IMeasurements
{
    getMeasurementsCount(): number;
    geMeasurement(i: number): IMeasurement;
    updateMeasurements(): void;

}