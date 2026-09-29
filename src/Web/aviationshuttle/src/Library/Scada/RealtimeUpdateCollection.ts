import { ActionArrayT } from "../Utilities/Generic/ActionArrayT";
import { Performer } from "../Performer";
import type { IActionAddRemoveT } from "../Interfaces/IActionAddRemoveT";
import type { IActionT } from "../Interfaces/IActionT";
import type { IRealtimeUpdate } from "./Interfaces/IRealtimeUpdate";
import type { IObjectCollection } from "../Interfaces/IObjectCollection";


export class RealtimeUpdateCollection implements IRealtimeUpdate, IActionT<IRealtimeUpdate> {
    pefrormer : Performer = new Performer()

    getRealtimeUpdate(): IActionT<number> {
        return this.action;
    }

    constructor(collection: IObjectCollection) {
        this.pefrormer.forEach(collection, this, "IRealtimeUpdate")

    }
    actionT(t: IRealtimeUpdate): void {
        this.action.addActionT(t.getRealtimeUpdate())
    }
    isEmptyActionT(): boolean { return false }


    action: IActionAddRemoveT<number> = new ActionArrayT()
}
