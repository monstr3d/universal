import type  { IActionAddRemove } from "./IActionAddRemove";
import type { IEventStart } from "./IEventStart";

export interface IEvent extends IEventStart {

    eventAction(): IActionAddRemove

}
