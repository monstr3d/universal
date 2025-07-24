import { IMeasurement } from "./Interfaces/IMeasurement";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";

export class TimeMeasurementProvider implements ITimeMeasurementProvider, IMeasurement {
    getMeasurementValue() {
        return this.time;
    }

    getTimeMeasurement(): IMeasurement {
        return this;
    }
    setTime(time: number): void {
        this.time = time;
    }
    getStep(): number {
        return 0;
    }
    setStep(time: number): void {
    }
    getName(): string {
        return "Time";
    }
    getType() {
        return 0;
    }

    getTime() : any
    {
        return this.time;
    }

    time: number = 0;
}