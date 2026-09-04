import type { IComponentCollection } from "./IComponentCollection";
import type { ITimerFactory } from "./ITimerFactory";
import type { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";

export interface IRealtimeCollection {

    setComponentCollection(collection: IComponentCollection): void

    getComponentCollection(): IComponentCollection

    isComponentCollectionRunning(): boolean

    setComponentCollectionRunning(running: boolean): void

    setTimerFactory(timerFactory: ITimerFactory): void

    setTimeProvider(timeProvider: ITimeMeasurementProvider): void
}

