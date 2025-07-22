import { ITimeMeasurementProvider } from "./ITimeMeasurementProvider";

export interface ITimeMeasurementConsumer
{
    getTimeMeasutement(): ITimeMeasurementProvider;

    setTimeMeasurement(measurement: ITimeMeasurementProvider): void;

    getInternalTime(): number;
    
}