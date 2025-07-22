import { ICategoryArrow } from "../../ICategoryArrow";
import { ICategoryObject } from "../../ICategoryObject";
import { ITimeMeasurementProvider } from "../ITimeMeasurementProvider";

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

}