import { getMaxListeners } from "node:stream";

export interface IArrayElementMeasurement {
    getMeasurementNames(): string[];
    getMeasurementTypes(): [];
    getMeasurementValues(): [];

}