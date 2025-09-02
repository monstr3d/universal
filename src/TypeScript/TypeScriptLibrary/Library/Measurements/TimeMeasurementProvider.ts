import { IMeasurement } from "./Interfaces/IMeasurement";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";

export class TimeMeasurementProvider implements ITimeMeasurementProvider, IMeasurement
{
    getMeasurementName(): string
    {
        return "Time";
    }

    getMeasurementType()
    {
        return 0;
    }

    getMeasurementValue()
    {
        return this.time;
    }

    getTimeMeasurement(): IMeasurement
    {
        return this;
    }

    setTime(time: number): void
    {
        this.time = time;
    }

    getStep(): number
    {
        return 0;
    }

    setStep(time: number): void
    {
    }

    getTime() : any
    {
        return this.time;
    }

    time: number = 0;
}