import { TimeSpan } from "../Utilities/DateTime/TimeSpan";
import  type { IEvent } from "./IEvent";

export interface ITimerEvent extends IEvent {
    getTimerEventTimeSpan(): TimeSpan
}