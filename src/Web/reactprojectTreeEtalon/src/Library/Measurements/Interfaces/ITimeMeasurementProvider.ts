/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IMeasurement } from "./IMeasurement";

export interface ITimeMeasurementProvider
{
    getTimeMeasurement(): IMeasurement;

    getTime(): number;

    setTime(time: number): void;

    getStep(): number;

    setStep(time: number): void;
}