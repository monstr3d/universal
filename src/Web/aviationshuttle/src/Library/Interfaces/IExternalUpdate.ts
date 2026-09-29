import type { IActionAddRemove } from "./IActionAddRemove";
import type { IObject } from "./IObject";
import type { IRealtimeCollection } from "./IRealtimeCollection";

export interface IExternalUpdate {
    getExternalUpdate(obj: IObject | undefined, realime: IRealtimeCollection, action: IActionAddRemove): void 
}