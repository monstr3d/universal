import { TimeSpan } from "../Utilities/DateTime/TimeSpan";
import type { ITimer } from "./ITimer";

export interface ITimerFactory {

    getTimerFromFactory(timeSpan: TimeSpan) : ITimer
}