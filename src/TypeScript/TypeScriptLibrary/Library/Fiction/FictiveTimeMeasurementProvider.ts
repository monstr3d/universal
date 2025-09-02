import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IMeasurement } from "../Measurements/Interfaces/IMeasurement";
import { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";

export class FictiveTimeMeasurementProvider implements ITimeMeasurementProvider {
    getTimeMeasurement(): IMeasurement {
        throw new OwnNotImplemented();
    }
    getTime(): number {
        throw new OwnNotImplemented();
    }
    setTime(time: number): void {
        throw new OwnNotImplemented();
    }
    getStep(): number {
        throw new OwnNotImplemented();
    }
    setStep(time: number): void {
        throw new OwnNotImplemented();
    }

}