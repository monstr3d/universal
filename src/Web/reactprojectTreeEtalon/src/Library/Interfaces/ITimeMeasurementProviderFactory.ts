import type { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";

export interface ITimeMeasurementProviderFactory {
        /// <summary>
        /// Creates Realtime provider
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="stepAction">Step Action</param>
        /// <param name="dataConsumer">Data Consumer</param>
        /// <param name="log">log</param>
        /// <param name="reason">Reason</param>
    /// <returns>The Realtime provider</returns>
    Create(isAbsolute: boolean, timeUnit: string, reason: string): ITimeMeasurementProvider 

    }
