/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IMeasurement } from "./IMeasurement";

export interface IMeasurements
{
    getMeasurementsCount(): number;
    getMeasurement(i: number): IMeasurement;
    updateMeasurements(): void;
    addMeasurement(measurement: IMeasurement): void;

}