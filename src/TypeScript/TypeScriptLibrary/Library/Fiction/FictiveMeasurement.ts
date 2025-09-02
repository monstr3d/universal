import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IMeasurement } from "../Measurements/Interfaces/IMeasurement";

export class FictiveMeasurement implements IMeasurement{
    getMeasurementName(): string {
        throw new OwnNotImplemented();
    }
    getMeasurementType() {
        throw new OwnNotImplemented();
    }
    getMeasurementValue() {
        throw new OwnNotImplemented();
    }

}