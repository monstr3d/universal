import { ICategoryArrow } from "../../Interfaces/ICategoryArrow";
import { ICategoryObject } from "../../Interfaces/ICategoryObject";
import { IStarted } from "../../Measurements/Interfaces/IStarted";
import { ITimeMeasurementProvider } from "../../Measurements/Interfaces/ITimeMeasurementProvider";

export interface IDataRuntime {

    updateRuntime(): void;

    /// <summary>
    /// Refreshes itself
    /// </summary>
    refreshRuntime(): void;

    /// <summary>
    /// Starts all components
    /// </summary>
    /// <param name="time">Start time</param>
    startRuntime(time: number): void;


    setTimeProvider(timeProvider: ITimeMeasurementProvider): void;

    getTimeProvider(): ITimeMeasurementProvider;

    getRumtimeObjects(): ICategoryObject[];

    getRunimeArrows(): ICategoryArrow[];

    getStarted(): IStarted[];

}