import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IMeasurement } from "../Measurements/Interfaces/IMeasurement";
import { IMeasurements } from "../Measurements/Interfaces/IMeasurements";

export class FictiveMeasurements implements IMeasurements
{
    getMeasurementsCount(): number {
        throw new OwnNotImplemented();
    }
    getMeasurement(i: number): IMeasurement {
        throw new OwnNotImplemented();
    }
    updateMeasurements(): void {
        throw new OwnNotImplemented();
    }
    addMeasurement(measurement: IMeasurement): void {
        throw new OwnNotImplemented();
    }

}