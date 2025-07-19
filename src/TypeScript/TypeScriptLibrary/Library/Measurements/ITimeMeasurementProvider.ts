import { IMeasurement } from "./IMeasurement";

export interface ITimeMeasurementProvider
{
    getTimeMeasurent(): IMeasurement;

    getTime(): number;

    setTime(time: number): void;

    getStep(): number;

    setStep(time: number): void;
}