import { TimeSpan } from "../Utilities/DateTime/TimeSpan";
import type { ITimerFactory } from "./ITimerFactory";

export interface ITimerConsumer {
    setTimer(timerFactory: ITimerFactory): void
    getTimeSpan(): TimeSpan
}