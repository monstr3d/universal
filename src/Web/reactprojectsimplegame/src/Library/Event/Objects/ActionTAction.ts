import { EmptyObject } from "../../EmptyObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IActionT } from "../../Interfaces/IActionT";

export class ActionTAction<T> extends EmptyObject implements IActionT<T> {

    constructor(action : IAction) {
        super("")
        this.typeName = "ActionTAction"
        this.types.push("IActionT")
        this.types.push("ActionTAction")
        this.action = action
    }

    actionT(t: T): void {
        this.any = t
        this.action.action()
    }

    isEmptyActionT(): boolean {
        return false
    }
     any : any

    protected action !: IAction
}