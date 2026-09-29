import { EmptyObject } from "../../EmptyObject";
import type { IActionAddRemoveT2 } from "../../Interfaces/IActionAddRemoveT2";
import type { IActionT2 } from "../../Interfaces/IActionT2";

export class ActionArrayT2<T1, T2> extends EmptyObject implements IActionAddRemoveT2<T1, T2> {
    constructor() {
        super("")
        this.types.push("IActionAddRemoveT2")
        this.types.push("ActionArrayT2")
        this.typeName = "ActionArrayT2"
    }

    isEmptyActionT2(): boolean {
        return this.actions.length == 0;
    }
    addActionT2(action: IActionT2<T1, T2> | undefined): void {
        if (this.performer.isEmptyActionT2(action)) return;
        if (action === undefined) return;
        this.actions.push(action)
    }
    removeActionT2(action: IActionT2<T1, T2>): void {
        if (this.performer.isEmptyActionT2(action)) return;
        if (action === undefined) return;
        this.performer.remove(this.actions, action)
    }
    clearActionsT2(): void {
        this.actions = [];
    }
    actionT2(t1: T1, t2 : T2): void {
        for (let action of this.actions)
            action.actionT2(t1, t2);
    }



    protected actions: IActionT2<T1, T2>[] = [];

}