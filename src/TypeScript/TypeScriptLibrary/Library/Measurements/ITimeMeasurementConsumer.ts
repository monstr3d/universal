import { IMeasurement } from "./IMeasurement";

export interface ITimeMeasurementConsumer
{
    getTimeMeasutement(): IMeasurement;

    setTimeMeasutement(measurement: IMeasurement): void;

    getInternalTime(): number;
    
}