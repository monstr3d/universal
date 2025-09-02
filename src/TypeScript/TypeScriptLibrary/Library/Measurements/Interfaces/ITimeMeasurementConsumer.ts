import { ITimeMeasurementProvider } from "./ITimeMeasurementProvider";

export interface ITimeMeasurementConsumer
{
    getTimeMeasurement(): ITimeMeasurementProvider;

    setTimeMeasurement(measurement: ITimeMeasurementProvider): void;

    getInternalTime(): number;
    
}