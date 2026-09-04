/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IStarted } from "../Measurements/Interfaces/IStarted";
import type { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";
import type { ICategoryArrow } from "./ICategoryArrow";
import type { ICategoryObject } from "./ICategoryObject";

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

export interface IDataRuntime
{

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

    stepRuntime(begin: number, end: number): void;

    
    addCategoryObjectToRuntime(object: ICategoryObject): void;


    getRuntimeObject(name: string): ICategoryObject;


    setTimeProvider(timeProvider: ITimeMeasurementProvider): void;

    getTimeProvider(): ITimeMeasurementProvider;

    getRuntimeObjects(): ICategoryObject[]


    getRuntimeArrows(): ICategoryArrow[]

    getStarted(): IStarted[]


}